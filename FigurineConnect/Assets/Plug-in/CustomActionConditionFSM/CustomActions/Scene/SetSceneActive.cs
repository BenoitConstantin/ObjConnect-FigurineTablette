using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Scene")]
public class SetSceneActive : ActionTask {

    public BBParameter<string> sceneNameBB;

    protected override void OnExecute()
    {
        base.OnExecute();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneNameBB.value));
        EndAction();
    }
}
