using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScrolling : MonoBehaviour {

    [SerializeField]
    int maxLevel = 4;

    [SerializeField]
    GameObject levelButtonPrefab;

    [SerializeField]
    Transform levelButtonParent;

    void Awake()
    {
        for(int i = 0; i < maxLevel; i++)
        {
            GameObject obj = Instantiate(levelButtonPrefab);
            obj.transform.SetParent(levelButtonParent);
            obj.GetComponent<LevelButton>().SetLevelNumber(i + 1);
        }
    }
}
