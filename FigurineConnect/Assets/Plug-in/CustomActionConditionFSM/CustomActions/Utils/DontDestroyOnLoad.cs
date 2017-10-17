using NodeCanvas.Framework;
using UnityEngine.SceneManagement;
using ParadoxNotion.Design;
using UnityEngine;

[Category("Utils")]
public class DontDestroyOnLoad : ActionTask {

    public BBParameter<GameObject> gameObjectBB;

    protected override void OnExecute()
    {
        base.OnExecute();
        Component.DontDestroyOnLoad(gameObjectBB.value);
        EndAction();
    }
}
