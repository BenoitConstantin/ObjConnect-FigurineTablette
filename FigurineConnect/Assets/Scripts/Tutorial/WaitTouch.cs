using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class WaitTouch : ActionTask {

    public BBParameter<int> touchNumber = 0;


    protected override void OnUpdate()
    {
        if (Input.touchCount == touchNumber.value)
            EndAction();
    }

}
