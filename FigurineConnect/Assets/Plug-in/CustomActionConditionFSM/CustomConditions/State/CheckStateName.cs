﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;

[Category("FSM")]
public class CheckStateName : ConditionTask {

    public enum Mode { PREVIOUS_STATE, NEXT_STATE}

    public Mode mode;
    public BBParameter<string> nameState;

    protected override bool OnCheck()
    {
        switch(mode)
        {
            case Mode.PREVIOUS_STATE: return ((FSM)this.ownerSystem).previousStateName.Equals(nameState.value);
            case Mode.NEXT_STATE: return ((FSM)this.ownerSystem).nextState.Equals(nameState.value);
        }

        return false;
    }
}
