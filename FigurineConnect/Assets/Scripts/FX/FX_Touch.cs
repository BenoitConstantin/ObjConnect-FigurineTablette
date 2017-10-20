using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseUnit))]
public class FX_Touch : MonoBehaviour {

    public GameObject fx;
    SurfacePositionSynchronizer surfacePosSync;
    string surfaceObjectID;
    public bool test;
    public SurfaceObject surfaceObject { get; private set; }
    // Use this for initialization
    void Start () {
        
        if (GetComponent<SurfacePositionSynchronizer>() != null) {
            surfaceObjectID = GetComponent<SurfacePositionSynchronizer>().name;
            if(SurfaceObjectDetector.Instance!=null) surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
        }
        test = GetComponent<BaseUnit>().test; 
	}

    // Update is called once per frame
    void Update() {
        if (test) {
            if (Input.GetMouseButtonDown(0) && GetComponent<BaseUnit>().IsSelected()) PlayFXs();
        } else {
            if (surfaceObject != null) {
                if (surfaceObject.isDetected) {
                    PlayFXs();
                }
            }
        }
    }
    void PlayFXs() {
        SoundManager.Instance.PlayClickSFX();
        if (fx != null) {
            /*fx.SetActive(true);
            Vector3 pos =  Camera.main.WorldToViewportPoint(transform.position);
            pos = Camera.main.ViewportToWorldPoint(pos);
            pos.z = 575.75f;
            fx.transform.position = pos;*/
        }
    }
}
