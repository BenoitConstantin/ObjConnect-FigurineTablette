using NodeCanvas.Framework;
using UnityEngine.SceneManagement;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

[Category("Scene")]
public class LoadScene : ActionTask {

    public BBParameter<string> sceneNameBB;
    public LoadSceneMode loadSceneMode;
    public bool asyncLoading = false;
    public BBParameter<AsyncOperation> asyncOperationMemoryBB;
    public bool waitForSceneLoaded = true;

    protected override void OnExecute()
    {
        base.OnExecute();


        if(!asyncLoading)
        {
            SceneManager.LoadScene(sceneNameBB.value, loadSceneMode);
            EndAction();
        }
        else
        {
            asyncOperationMemoryBB.value = SceneManager.LoadSceneAsync(sceneNameBB.value, loadSceneMode);

            if (waitForSceneLoaded)
                SceneManager.sceneLoaded += WaitSceneLoaded;
            else
                EndAction();
        }
    }

    void WaitSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name.Equals(sceneNameBB.value))
        {
            StartCoroutine(IWaitSceneLoaded());
            SceneManager.sceneLoaded -= WaitSceneLoaded;
        }
    }

    IEnumerator IWaitSceneLoaded()
    {
        yield return null;
        EndAction();
    }


}
