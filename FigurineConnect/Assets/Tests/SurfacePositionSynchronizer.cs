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
        surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
    }

    void Update()
    {
        if (surfaceObject.detected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(surfaceObject.currentPosition.x, surfaceObject.currentPosition.y, distanceFromCamera));
            transform.LookAt(transform.position + new Vector3(surfaceObject.direction.x, 0, surfaceObject.direction.y));
        }
    }
}
