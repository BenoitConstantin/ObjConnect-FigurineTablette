using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    [SerializeField]
    int levelNumber = 1;

    [SerializeField]
    Text text; 

    public void SelectLevel()
    {
        GameManager.Instance.LoadLevel(levelNumber);
    }

    public void SetLevelNumber(int number)
    {
        this.gameObject.name = "Level_" + number;
        this.levelNumber = number;
        text.text = "Level " + number;
    }
}
