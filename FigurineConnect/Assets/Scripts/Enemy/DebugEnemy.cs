using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEnemy : MonoBehaviour {

    private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) {
            rigid.MovePosition(transform.position + Vector3.up * (Time.deltaTime * 200));
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rigid.MovePosition(transform.position + Vector3.down * (Time.deltaTime * 200));
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigid.MovePosition(transform.position + Vector3.left * (Time.deltaTime * 200));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigid.MovePosition(transform.position + Vector3.right * (Time.deltaTime * 200));
        }

    }
}
