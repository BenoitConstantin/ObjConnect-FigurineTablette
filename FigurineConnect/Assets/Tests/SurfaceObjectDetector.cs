using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceObjectDetector : SimpleSingleton<SurfaceObjectDetector>
{

    public enum State { CALIBRATING, PROCESSING_POSITION_ROTATION }
    public enum CalibrationStatus { CALIBRATED, PROCESSING, TOO_MANY_POINTS_DETECTED, SURFACE_OBJ_NOT_DEFINED }

    public SurfaceObject[] surfaceObjects;

    [Tooltip("Distance threshold for detecting point on triangle")]
    public float positionThreshold = 0.1f;
    [Tooltip("When a surface object is already calibrated, an average is made with that rage on the next values")]
    public float calibrationAverageRate = 0.1f;

    private State currentState = State.PROCESSING_POSITION_ROTATION;
    public State CurrentState
    {
        get { return currentState; }
    }

    //Variables for Calibration purpose
    private SurfaceObject calibratedSurfaceObject = null;
    private CalibrationStatus currentCalibrationStatus = CalibrationStatus.CALIBRATED;

    void Update()
    {
        switch (currentState)
        {
            case State.CALIBRATING:
                currentCalibrationStatus = Calibrate(calibratedSurfaceObject);

                Debug.Log(currentCalibrationStatus);

                break;
            case State.PROCESSING_POSITION_ROTATION:

                ProcessPositions();

                /*   Debug.Log(objects[0].firstPointDistance);
                   Debug.Log(objects[0].secondPointDistance);
                   Debug.Log(objects[0].thirdPointDistance); */

                break;

        }
    }


    public void ProcessPositions()
    {

        foreach (SurfaceObject obj in surfaceObjects)
        {
            obj.isDetected = false;
        }

        if (Input.touchCount < 3)
            return;


        List<Vector2> availablePositions = new List<Vector2>();

        foreach (Touch t in Input.touches)
        {
            availablePositions.Add(t.position);
        }

        Vector2[] positions = new Vector2[3];
        List<SurfaceObject> availableSurfaceObjects = new List<SurfaceObject>(surfaceObjects); //For security purpose, when more than one triangle is detected, a surfaceObject can't be detected twice.

        //Brute force algorithm for finding triangles   
        int i = 0;
        while (availablePositions.Count >= 3 && i < availablePositions.Count)
        {
            bool reset = false; //Reset the search because a triangle is detected and somes points are remove from the solution

            for (int j = (i + 1) % availablePositions.Count; j != i && availablePositions.Count >= 3; j = (j + 1) % availablePositions.Count)
            {
                for (int k = (j + 1) % availablePositions.Count; k != i && k != j && availablePositions.Count >= 3; k = (k + 1) % availablePositions.Count)
                {
                    positions[0] = availablePositions[i];
                    positions[1] = availablePositions[j];
                    positions[2] = availablePositions[k];

                    foreach (SurfaceObject obj in availableSurfaceObjects)
                    {
                        if (DetectObject(obj, positions))
                        {
                            obj.currentPosition = BarycentricPoint(positions);
                            obj.direction = FarthestPointToBarycentricPoint(positions) - obj.currentPosition;
                            obj.isDetected = true;

                            availablePositions.Remove(positions[0]);
                            availablePositions.Remove(positions[1]);
                            availablePositions.Remove(positions[2]);

                            reset = true;
                            i = 0;
                            availableSurfaceObjects.Remove(obj);

                            Debug.Log(obj.id + " DETECTED !!!!!!!!!!!!!!!!!!!!!");
                            break;
                        }
                    }

                    if (reset)
                        break;
                }

                if (reset)
                    break;
            }

            if(!reset)
                i++;
        }
    }


    public void StartCalibration(SurfaceObject obj)
    {
        this.currentState = State.CALIBRATING;
        this.calibratedSurfaceObject = obj;
        obj.isCalibrated = false;
    }

    public void StopCalibration()
    {
        this.currentState = State.PROCESSING_POSITION_ROTATION;
        this.calibratedSurfaceObject = null;
    }

    CalibrationStatus Calibrate(SurfaceObject obj)
    {
        if (Input.touchCount < 3)
        {
            return CalibrationStatus.PROCESSING;
        }
        else if (Input.touchCount > 3)
        {
            return CalibrationStatus.TOO_MANY_POINTS_DETECTED;
        }
        else
        {
            if (obj == null)
            {
                return CalibrationStatus.SURFACE_OBJ_NOT_DEFINED;
            }

            Vector2[] positions = new Vector2[3];

            for (int i = 0; i < 3; i++)
                positions[i] = Input.GetTouch(i).position;

            Vector2 barycentricPoint = BarycentricPoint(positions);


            if (obj.isCalibrated)
            {
                obj.calibratedDistances[0] = (obj.calibratedDistances[0] + calibrationAverageRate * Vector2.Distance(Input.GetTouch(0).position, barycentricPoint)) / (1+ calibrationAverageRate);
                obj.calibratedDistances[1] = (obj.calibratedDistances[1] + calibrationAverageRate * Vector2.Distance(Input.GetTouch(1).position, barycentricPoint)) / (1 + calibrationAverageRate);
                obj.calibratedDistances[2] = (obj.calibratedDistances[2] + calibrationAverageRate * Vector2.Distance(Input.GetTouch(2).position, barycentricPoint)) / (1 + calibrationAverageRate);
            }
            else
            {
                obj.calibratedDistances[0] = Vector2.Distance(Input.GetTouch(0).position, barycentricPoint);
                obj.calibratedDistances[1] = Vector2.Distance(Input.GetTouch(1).position, barycentricPoint);
                obj.calibratedDistances[2] = Vector2.Distance(Input.GetTouch(2).position, barycentricPoint);
            }


            obj.isCalibrated = true;
            return CalibrationStatus.CALIBRATED;
        }
    }

    /// <summary>
    /// Check if the triangle formed by the 3 points can correspond to the calibrated SurfaceObject
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="points">an array of 3 points</param>
    /// <returns></returns>
    public bool DetectObject(SurfaceObject obj, Vector2[] points)
    {
        Vector2 barycentricPoint = BarycentricPoint(points);

        float[] distances = new float[3];

        distances[0] = Vector2.Distance(points[0], barycentricPoint);
        distances[1] = Vector2.Distance(points[1], barycentricPoint);
        distances[2] = Vector2.Distance(points[2], barycentricPoint);

      /*  Debug.Log("FirstDistance : " + distances[0]);
        Debug.Log("SecondeDistance : " + distances[1]);
        Debug.Log("ThirdDistance : " + distances[2]); */

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (i != j && i != k && j != k)
                    {
                        if (Mathf.Abs(obj.calibratedDistances[0] - distances[i]) <= positionThreshold
                            &&
                            Mathf.Abs(obj.calibratedDistances[1] - distances[j]) <= positionThreshold
                            &&
                            Mathf.Abs(obj.calibratedDistances[2] - distances[k]) <= positionThreshold)
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;

    }

    public SurfaceObject GetSurfaceObject(string id)
    {
        foreach (SurfaceObject objConfig in surfaceObjects)
        {
            if (objConfig.id.Equals(id))
                return objConfig;
        }

        return null;
    }

    Vector2 BarycentricPoint(Vector2[] points)
    {
        Vector2 sum = Vector2.zero;

        for (int i = 0; i < points.Length; i++)
            sum += points[i];

        return sum / points.Length;
    }

    Vector2 FarthestPointToBarycentricPoint(Vector2[] points)
    {
        Vector2 barycentricPoint = BarycentricPoint(points);
        Vector2 farthestPoint = barycentricPoint;
        float maxDistance = 0;

        foreach(Vector2 point in points)
        {
            float distance = Vector2.Distance(point, barycentricPoint);

            if(distance > maxDistance)
            {
                farthestPoint = point;
                maxDistance = distance;
            }
        }

        return farthestPoint;
    }
}
