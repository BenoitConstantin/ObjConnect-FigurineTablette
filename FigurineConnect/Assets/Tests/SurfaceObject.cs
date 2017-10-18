using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SurfaceObject {
    public string id;

    public float[] calibratedDistances = new float[3];

    public Vector2 currentPosition;
    public Vector2 direction;

    public bool isCalibrated = false;
    public bool isDetected = false;

}
