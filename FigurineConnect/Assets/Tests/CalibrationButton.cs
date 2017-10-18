using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Only for test purpose
/// </summary>
public class CalibrationButton : MonoBehaviour {

    [SerializeField]
    SurfacePointsDetector surfacePointsDetector;

    [SerializeField]
    Text text;

    [SerializeField]
    string surfaceObjectID;

    public void OnClick()
    {
        if(surfacePointsDetector.CurrentState == SurfacePointsDetector.State.PROCESSING_POSITION_ROTATION)
        {
            surfacePointsDetector.StartCalibration(surfaceObjectID);
            text.text = "Stop Calibration";
        }
        else
        {
            surfacePointsDetector.StopCalibration();
            text.text = "Calibrate";
        }
    }


}
