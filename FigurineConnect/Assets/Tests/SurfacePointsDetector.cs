using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfacePointsDetector : MonoBehaviour {

    const float poundToMeter = 0.0254f;


    [System.Serializable]
    public class ObjectConfiguration
    {
        public float firstPointDistance, secondPointDistance, thirdPointDistance;
        public string id;
        public Vector3 currentPosition;
    }

    public ObjectConfiguration[] objects;

    public List<ObjectConfiguration> detectedObjects;
    public float positionThreshold = 0.1f;

    [SerializeField]
    Transform cube;

    bool initiated = false;

    void Update()
    {
        if(Input.touchCount < 3)
        {
            return;
        }

        Vector2 firstPoint = Input.GetTouch(0).position;
        Vector2 secondPoint = Input.GetTouch(1).position;
        Vector2 thirdPoint = Input.GetTouch(2).position;

       /* Debug.Log("Dpi : " + Screen.dpi);
        Debug.Log("First Point : " + firstPoint);
        Debug.Log("Second Point : " + secondPoint);
        Debug.Log("Third Point : " + thirdPoint);
        Debug.Log("Barycentric point : " + barycentricPoint); */

        if (!initiated)
        {

            Vector2 barycentricPoint = BarycentricPoint(firstPoint, secondPoint, thirdPoint);

            objects[0].firstPointDistance = Vector2.Distance(firstPoint, barycentricPoint);
            objects[0].secondPointDistance = Vector2.Distance(secondPoint, barycentricPoint);
            objects[0].thirdPointDistance = Vector2.Distance(thirdPoint, barycentricPoint);
            initiated = true;

            Debug.Log("INITIATED");
        }
        else
        {
            foreach (ObjectConfiguration obj in objects)
            {
                if (DetectObject(obj.id, firstPoint, secondPoint, thirdPoint))
                {
                    if (!detectedObjects.Exists((x) => { return x.id.Equals(obj.id); }))
                        detectedObjects.Add(obj);

                    Vector3 position = BarycentricPoint(firstPoint,secondPoint,thirdPoint);
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
        }


        Debug.Log("\\\\\\");
    }


    public bool DetectObject(string id, Vector2 firstPoint, Vector2 secondPoint, Vector2 thirdPoint)
    {
        ObjectConfiguration obj = GetObject(id);
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

    ObjectConfiguration GetObject(string id)
    {
        foreach(ObjectConfiguration objConfig in objects)
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
