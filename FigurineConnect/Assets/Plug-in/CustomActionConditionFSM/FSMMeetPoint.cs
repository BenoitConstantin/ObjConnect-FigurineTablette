using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;

public class FSMMeetPoint : FSMState
{
    protected override void OnEnter()
    {
        base.OnEnter();
        Finish();

        if (this.outConnections.Count != 0)
            CheckTransitions();
        else
        {
            this.FSM.Stop(true);
        }
    }
}
