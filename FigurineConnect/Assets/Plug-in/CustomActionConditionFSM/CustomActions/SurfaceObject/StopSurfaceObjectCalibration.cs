using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("SurfaceObject")]
public class StopSurfaceObjectCalibration : ActionTask
{
    protected override void OnExecute()
    {
        SurfaceObjectDetector.Instance.StopCalibration();
        EndAction();
    }
}
