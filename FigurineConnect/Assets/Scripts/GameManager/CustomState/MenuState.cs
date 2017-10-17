using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;

[Category("GameManager")]
public class MenuState : ActionState, ILevelLoadable {


    public void LoadLevel(int number)
    {
        this.FSM.SendEvent<string>("LoadParty", "Level_" + number);
    }

}
