using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Touch : MonoBehaviour {

    public GameObject fx;
    SurfacePositionSynchronizer surfacePosSync;

    public SurfaceObject surfaceObject { get; private set; }

    // Use this for initialization
    void Start () {
        string surfaceObjectID;
        if (GetComponent<SurfacePositionSynchronizer>() != null) {
            surfaceObjectID = GetComponent<SurfacePositionSynchronizer>().name;
            surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
        } else {
            enabled = false;
        }
	}

    // Update is called once per frame
    void Update() {
        if (surfaceObject.isDetected) {

            SoundManager.Instance.PlayClickSFX();
        }
    }
}
