using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    public float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLife(float delta) {
        health -= delta;
        if(health<= 0) {
            Destroy(gameObject);
        }
    }
}
