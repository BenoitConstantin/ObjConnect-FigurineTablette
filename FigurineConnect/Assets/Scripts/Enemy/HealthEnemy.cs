using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    public float life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLife(float delta) {
        life -= delta;
        if (life < 0) {
            Debug.Log("Enemy destroyed");
            Destroy(gameObject);
        }
    }
}
