using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;


public class CheckType : ConditionTask {

    public BBParameter<object> obj;
    public System.Type type;

    protected override bool OnCheck()
    {
        return type == obj.value.GetType();
    }
}
