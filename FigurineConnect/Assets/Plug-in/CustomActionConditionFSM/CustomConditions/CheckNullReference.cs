using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class CheckNullReference : ConditionTask
{
    public BBParameter<object> obj;

    protected override bool OnCheck()
    {
        return obj.value != null;
    }
}

