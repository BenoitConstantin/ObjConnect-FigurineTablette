using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.StateMachines;

public class Tutorial : SimpleSingleton<Tutorial> {

    [SerializeField]
    FSMOwner fsmOwner;

    public bool IsFinished
    {
        get { return fsmOwner.blackboard.GetValue<bool>("isFinished"); }
    }


}
