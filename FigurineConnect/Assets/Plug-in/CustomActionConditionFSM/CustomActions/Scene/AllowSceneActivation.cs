using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Scene")]
public class AllowSceneActivation : ActionTask {

    public BBParameter<AsyncOperation> asyncOperation;
    public BBParameter<bool> allowActivationBB;
    public bool waitForSceneLoad;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (allowActivationBB.value)
        {
            if(asyncOperation.value.allowSceneActivation == false)
                asyncOperation.value.allowSceneActivation = true;

            if(asyncOperation.value.isDone)
                EndAction();
        }
        else
        {
            asyncOperation.value.allowSceneActivation = allowActivationBB.value;
            EndAction();
        }
    }

}
