using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour {

    public bool inGame { get; private set; }
    public float actionTime;

    // Use this for initialization
    void Start () {
        inGame = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
