using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRotation : MonoBehaviour {

    public float angleSpeed = 25;
    public bool forward;


    void Start() {;
    }

    void FixedUpdate () {
        transform.Rotate(forward ?Vector3.forward: Vector3.up, angleSpeed * Time.deltaTime);
	}
}
