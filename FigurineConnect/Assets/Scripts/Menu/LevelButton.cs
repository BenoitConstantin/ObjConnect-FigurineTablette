using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    [SerializeField]
    int levelNumber = 1;


    public void SelectLevel()
    {
        GameManager.Instance.LoadLevel(levelNumber);
    }

}
