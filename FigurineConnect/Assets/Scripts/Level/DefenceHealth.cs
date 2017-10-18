using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceHealth : MonoBehaviour {
    public int health = 200;

    void Update()
    {
        if (health <= 0)
        {
            //End game. 
        }
    }
}
