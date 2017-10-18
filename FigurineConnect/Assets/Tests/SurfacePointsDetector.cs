using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfacePointsDetector : MonoBehaviour {

    const float poundToMeter = 0.0254f;

    public enum State { CALIBRATING, PROCESSING_POSITION_ROTATION}
    public enum CalibrationStatus { CALIBRATED, PROCESSING, TOO_MANY_POINTS_DETECTED, ID_NOT_DEFINED}


    [System.Serializable]
    public class SurfaceObject
    {
        public float firstPointDistance, secondPointDistance, thirdPointDistance;
        public string id;
        public Vector3 currentPosition;
    }

    public SurfaceObject[] objects;

    public List<SurfaceObject> detectedObjects;
    public float positionThreshold = 0.1f;

    [SerializeField]
    Transform cube;

    bool initiated = false;

    private State currentState = State.PROCESSING_POSITION_ROTATION;
    public State CurrentState
    {
        get { return currentState; } 
    }

    //Variables for Calibration purpose
    private string calibrationID = null;
    private CalibrationStatus currentCalibrationStatus = CalibrationStatus.CALIBRATED;

    void Update()
    {
        switch(currentState)
        {
            case State.CALIBRATING:
                currentCalibrationStatus = Calibrate(calibrationID);

                Debug.Log(currentCalibrationStatus);

                break;
            case State.PROCESSING_POSITION_ROTATION:

                if (Input.touchCount < 3)
                    return;

                Vector2 firstPoint = Input.GetTouch(0).position;
                Vector2 secondPoint = Input.GetTouch(1).position;
                Vector2 thirdPoint = Input.GetTouch(2).position;

                foreach (SurfaceObject obj in objects)
                {
                    if (DetectObject(obj.id, firstPoint, secondPoint, thirdPoint))
                    {
                        if (!detectedObjects.Exists((x) => { return x.id.Equals(obj.id); }))
                            detectedObjects.Add(obj);

                        Vector3 position = BarycentricPoint(firstPoint, secondPoint, thirdPoint);
                        position.z = 10;
                        obj.currentPosition = Camera.main.ScreenToWorldPoint(position);

                        Debug.Log("DETECTED !!!!!!!!!!!!!!!!!!!!!");
                    }
                }

                if (detectedObjects.Count > 0)
                    cube.position = detectedObjects[0].currentPosition;


                Debug.Log(objects[0].firstPointDistance);
                Debug.Log(objects[0].secondPointDistance);
                Debug.Log(objects[0].thirdPointDistance);

                break;

        }





        Debug.Log("\\\\\\");
    }

    public void StartCalibration(string id)
    {
        this.currentState = State.CALIBRATING;
        this.calibrationID = id;
    }

    public void StopCalibration()
    {
        this.currentState = State.PROCESSING_POSITION_ROTATION;
        this.calibrationID = null;
    }

    CalibrationStatus Calibrate(string id)
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
            SurfaceObject obj = GetSurfaceObject(id);

            if(obj == null)
            {
                return CalibrationStatus.ID_NOT_DEFINED;
            }

            Vector2 barycentricPoint = BarycentricPoint(Input.GetTouch(0).position, Input.GetTouch(1).position, Input.GetTouch(2).position);

            objects[0].firstPointDistance = Vector2.Distance(Input.GetTouch(0).position, barycentricPoint);
            objects[0].secondPointDistance = Vector2.Distance(Input.GetTouch(1).position, barycentricPoint);
            objects[0].thirdPointDistance = Vector2.Distance(Input.GetTouch(2).position, barycentricPoint);

            return CalibrationStatus.CALIBRATED;
        }
    }

    public bool DetectObject(string id, Vector2 firstPoint, Vector2 secondPoint, Vector2 thirdPoint)
    {
        SurfaceObject obj = GetSurfaceObject(id);
        if(obj == null)
        {
            Debug.LogError("No object with this id");
            return false;
        }

        Vector2 barycentricPoint = BarycentricPoint(firstPoint, secondPoint, thirdPoint);
        float firstDistance = Vector2.Distance(firstPoint, barycentricPoint);
        float secondDistance = Vector2.Distance(secondPoint, barycentricPoint);
        float thirdDistance = Vector2.Distance(thirdPoint, barycentricPoint);

        Debug.Log("FirstDistance : " + firstDistance);
        Debug.Log("SecondeDistance : " + secondDistance);
        Debug.Log("ThirdDistance : " + thirdDistance);

        if (
            (Mathf.Abs(obj.firstPointDistance - firstDistance) <= positionThreshold && Mathf.Abs(obj.secondPointDistance- secondDistance) <= positionThreshold)
            || (Mathf.Abs(obj.secondPointDistance- firstDistance) <= positionThreshold && Mathf.Abs(obj.firstPointDistance - secondDistance) <= positionThreshold)
            )
            return true;

        return false;

    }

    SurfaceObject GetSurfaceObject(string id)
    {
        foreach(SurfaceObject objConfig in objects)
        {
            if (objConfig.id.Equals(id))
                return objConfig;
        }

        return null;
    }

    Vector2 BarycentricPoint(Vector2 firstPoint, Vector2 secondPoint, Vector2 thirdPoint)
    {
        return (firstPoint + secondPoint + thirdPoint) / 3f;
    }
}
