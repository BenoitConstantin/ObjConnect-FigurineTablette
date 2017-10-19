using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationButton : MonoBehaviour {

    [SerializeField]
    Text surfaceObjectNameText;

    CalibrationMenu calibrationMenu;
    SurfaceObject surfaceObject;

	public void Init(CalibrationMenu calibrationMenu, SurfaceObject surfaceObject)
    {
        this.calibrationMenu = calibrationMenu;
        this.surfaceObject = surfaceObject;

        surfaceObjectNameText.text = surfaceObject.id;
    }

    public void Calibrate()
    {
        calibrationMenu.Calibrate(this.surfaceObject);
    }

}
