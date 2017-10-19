using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class EndTutorial : ActionTask {

    protected override void OnExecute()
    {
        GameManager.Instance.EndTutorial();
        EndAction();
    }
}
