using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.StateMachines;

public class GameManager : SimpleSingleton<GameManager> {

    [SerializeField]
    FSMOwner fsmOwner;

    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    public void LoadLevel(int number)
    {
        IState currentState = fsmOwner.GetCurrentState();

        if(currentState is ILevelLoadable)
        {
            ((ILevelLoadable)currentState).LoadLevel(number);
        }
    }

    public void EndParty(bool victory)
    {
        fsmOwner.SendEvent("EndParty", victory);
    }

    public void EndTutorial()
    {
        fsmOwner.SendEvent("EndTutorial");
    }

}
