using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Only for test purpose
/// </summary>
public class Test_CalibrationButton : MonoBehaviour {

    [SerializeField]
    SurfaceObjectDetector surfacePointsDetector;

    [SerializeField]
    Text text;

    [SerializeField]
    string surfaceObjectID;

    public void OnClick()
    {
        if(surfacePointsDetector.CurrentState == SurfaceObjectDetector.State.PROCESSING_POSITION_ROTATION)
        {
            surfacePointsDetector.StartCalibration(SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID));
            text.text = "Stop Calibration";
        }
        else
        {
            surfacePointsDetector.StopCalibration();
            text.text = "Calibrate " + surfaceObjectID;
        }
    }


}
