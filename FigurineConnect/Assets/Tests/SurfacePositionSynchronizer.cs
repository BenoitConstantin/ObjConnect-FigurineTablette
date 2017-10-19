using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfacePositionSynchronizer : MonoBehaviour {

    [SerializeField]
    string surfaceObjectID;

    [SerializeField]
    new Transform transform;

    public float distanceFromCamera = 10;

    public float positionLerpTime = 5f;
    public float rotationLerpTime = 0.1f;

    public float snapThreshold = 2f;

    public Vector3 rotationOffset;

    SurfaceObject surfaceObject;

    Vector3 targetPosition;
    Vector3 targetLookAt;

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
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(surfaceObject.currentPosition.x, surfaceObject.currentPosition.y, distanceFromCamera));
            targetLookAt = targetPosition + Camera.main.transform.TransformVector(surfaceObject.direction);

            if (Vector3.Distance(transform.position, targetPosition) > snapThreshold)
                transform.position = targetPosition;
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, positionLerpTime * Time.fixedDeltaTime);
        transform.LookAt(Vector3.Lerp(transform.position + transform.forward, targetLookAt, rotationLerpTime * Time.fixedDeltaTime), this.transform.forward);
        Vector3 euler = transform.eulerAngles;
        euler.x = euler.y = 0;
        transform.eulerAngles = euler;
    }
}
