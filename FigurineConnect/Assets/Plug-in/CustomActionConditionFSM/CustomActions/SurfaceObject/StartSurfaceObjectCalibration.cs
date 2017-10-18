using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("SurfaceObject")]
public class StartSurfaceObjectCalibration : ActionTask {

    public string surfaceObjectID;
    SurfaceObject surfaceObject;

    protected override string OnInit()
    {
        surfaceObject = SurfaceObjectDetector.Instance.GetSurfaceObject(surfaceObjectID);
        return base.OnInit();
    }

    protected override void OnExecute()
    {
        SurfaceObjectDetector.Instance.StartCalibration(surfaceObject);
        EndAction();
    }

}
