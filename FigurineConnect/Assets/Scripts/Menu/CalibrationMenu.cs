using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationMenu : MonoBehaviour {

    [SerializeField]
    GameObject calibrationButtonPrefab;

    [SerializeField]
    Transform calibrationButtonParent;

    [SerializeField]
    Text calibrationText;

    public float timeToCalibrate = 1f;
    public float timeOutCalibration = 0.3f;

    List<CalibrationButton> calibrationButtons = new List<CalibrationButton>();

   

    float timerCalibration;
    float timerOutCalibration;
    SurfaceObject calibratingSurfaceObject = null;

    void Awake()
    {
        foreach(SurfaceObject surfaceObject in SurfaceObjectDetector.Instance.surfaceObjects)
        {
            GameObject obj = Instantiate(calibrationButtonPrefab);
            CalibrationButton calibrationButton =  obj.GetComponent<CalibrationButton>();
            calibrationButton.Init(this, surfaceObject);
            calibrationButtons.Add(calibrationButton);
            calibrationButton.transform.SetParent(calibrationButtonParent);
        }

        calibrationText.enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        if(Time.time <= timerCalibration)
        {
            foreach (CalibrationButton calibrationButton in calibrationButtons)
                calibrationButton.gameObject.SetActive(true);

            this.enabled = false;
            calibrationText.enabled = false;
        }

        if (!SurfaceObjectDetector.Instance.calibratingSurfaceObject.isDetected)
        {
            timerOutCalibration = Time.time + timeOutCalibration;
        }
        else
            timerCalibration += Time.deltaTime;

        if (Time.time > timerOutCalibration)
            timerCalibration = 0;
    }

    public void Calibrate(SurfaceObject surfaceObject)
    {
        foreach (CalibrationButton calibrationButton in calibrationButtons)
            calibrationButton.gameObject.SetActive(false);

        SurfaceObjectDetector.Instance.StartCalibration(surfaceObject);

        calibrationText.enabled = true;
        calibrationText.text = "Calibrating : " + surfaceObject.id;
        this.enabled = true;
    }

}
