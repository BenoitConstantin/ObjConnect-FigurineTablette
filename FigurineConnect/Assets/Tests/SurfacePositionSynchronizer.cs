using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfacePositionSynchronizer : MonoBehaviour {

    [SerializeField]
    string surfaceObjectID;

    [SerializeField]
    new Transform transform;

    public float distanceFromCamera = 10;

    SurfaceObject surfaceObject;


    void Start()
    {
        if (SurfaceObjectDetector.Instance == null) {
            enabled = false;
        } else {
            surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
            if (surfaceObject == null) enabled = false;
        }
    }

    void Update()
    {
        if (surfaceObject.isDetected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(surfaceObject.currentPosition.x, surfaceObject.currentPosition.y, distanceFromCamera));
            transform.LookAt(transform.position + Camera.main.transform.TransformVector(surfaceObject.direction));
        }
    }
}
