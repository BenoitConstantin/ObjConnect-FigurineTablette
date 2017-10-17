using NodeCanvas.Framework;
using UnityEngine.SceneManagement;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

[Category("Scene")]
public class UnloadScene : ActionTask {

    public BBParameter<string> sceneNameBB;
    public bool waitForSceneUnloaded = true;

    protected override void OnExecute()
    {
        base.OnExecute();

        SceneManager.UnloadSceneAsync(sceneNameBB.value);

        if (waitForSceneUnloaded)
            SceneManager.sceneUnloaded += WaitSceneUnloaded;
        else
            EndAction();
    }

    void WaitSceneUnloaded(Scene scene)
    {
        if (scene.name.Equals(sceneNameBB.value))
        {
            SceneManager.sceneUnloaded -= WaitSceneUnloaded;
            StartCoroutine(IWaitSceneUnloaded());
        }
    }

    IEnumerator IWaitSceneUnloaded()
    {
        yield return null;
        EndAction();
    }
}
