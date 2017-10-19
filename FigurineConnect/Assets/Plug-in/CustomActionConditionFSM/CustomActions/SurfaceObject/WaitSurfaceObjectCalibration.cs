using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using DG.Tweening;

[Category("SurfaceObject")]
public class WaitSurfaceObjectCalibration : ActionTask {

    public string surfaceObjectID;
    public float timeToCalibrate = 1f;
    public float timeOutCalibration = 0.3f;

    public BBParameter<Animator> animator;
    public Animator flashANimator;
    public Image flashImage;

    SurfaceObject surfaceObject;

    float lastTimeDetected = -1;
    float calibrationTimer;


    protected override string OnInit()
    {
        surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
        return base.OnInit();
    }

    protected override void OnExecute()
    {
        lastTimeDetected = 0;
        animator.value.Play("Play");
        animator.value.speed = 0;
    }

    protected override void OnUpdate()
    {
        //Out of calibration
        if(Time.time > lastTimeDetected + timeOutCalibration)
        {
            lastTimeDetected = -1;
            calibrationTimer = 0;
            animator.value.Play("Play",0,0);
            animator.value.speed = 0;
        }

        if(surfaceObject.isDetected)
        {
            animator.value.speed = 1;
            if (SurfaceObjectDetector.Instance.currentCalibrationStatus == SurfaceObjectDetector.CalibrationStatus.CALIBRATED)
            {
                lastTimeDetected = Time.time;
                calibrationTimer += Time.deltaTime;

                if (calibrationTimer > timeToCalibrate)
                    EndAction();
            }
        }

    }
}
