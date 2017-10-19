using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationMenu : MonoBehaviour
{

    [SerializeField]
    GameObject calibrationButtonPrefab;

    [SerializeField]
    Transform calibrationButtonParent;

    [SerializeField]
    Text calibrationText;

    public float timeToCalibrate = 1f;
    public float timeOutCalibration = 0.3f;

    List<CalibrationButton> calibrationButtons = new List<CalibrationButton>();



    float timerCalibration = -1;
    float timerOutCalibration = -1;
    SurfaceObject calibratingSurfaceObject = null;

    void Awake()
    {
        foreach (SurfaceObject surfaceObject in SurfaceObjectDetector.Instance.surfaceObjects)
        {
            GameObject obj = Instantiate(calibrationButtonPrefab);
            CalibrationButton calibrationButton = obj.GetComponent<CalibrationButton>();
            calibrationButton.Init(this, surfaceObject);
            calibrationButtons.Add(calibrationButton);
            calibrationButton.transform.SetParent(calibrationButtonParent);
        }

        calibrationText.enabled = false;
    }

    void OnEnable()
    {
        calibrationText.enabled = false;

        foreach (CalibrationButton calibrationButton in calibrationButtons)
            calibrationButton.gameObject.SetActive(true);

        timerCalibration = -1;
        timerOutCalibration = -1;
    }

    void OnDisable()
    {
        foreach (CalibrationButton calibrationButton in calibrationButtons)
            calibrationButton.gameObject.SetActive(true);

        calibrationText.enabled = false;

        SurfaceObjectDetector.Instance.StopCalibration();
    }

    void Update()
    {

        if (SurfaceObjectDetector.Instance.CurrentState != SurfaceObjectDetector.State.CALIBRATING)
            return;

        if (Time.time + timeToCalibrate <= timerCalibration)
        {
            foreach (CalibrationButton calibrationButton in calibrationButtons)
                calibrationButton.gameObject.SetActive(true);

            calibrationText.enabled = false;
            SurfaceObjectDetector.Instance.StopCalibration();
        }
        else
        {
            if (!SurfaceObjectDetector.Instance.calibratingSurfaceObject.isDetected)
            {
                timerOutCalibration = Time.time + timeOutCalibration;
            }
            else
            {
                timerCalibration += 2f * Time.deltaTime;
                timerOutCalibration = -1;
            }

            if (timerOutCalibration != -1 && Time.time > timerOutCalibration)
            {
                timerCalibration = Time.time;
            }
        }
    }

    public void Calibrate(SurfaceObject surfaceObject)
    {
        foreach (CalibrationButton calibrationButton in calibrationButtons)
            calibrationButton.gameObject.SetActive(false);

        SurfaceObjectDetector.Instance.StartCalibration(surfaceObject);

        calibrationText.enabled = true;
        calibrationText.text = "Calibrating : " + surfaceObject.id;
        timerCalibration = Time.time;
        timerOutCalibration = -1;
    }

}
