using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : BaseUnit {

    public GameObject arcBullet;
    
	// Use this for initialization
	void Start () {
        SetCamera();
        arcBullet.GetComponent<SpriteRenderer>().enabled = false;
    }
	
    public void SetDamageAttack(int value) {
        arcBullet.GetComponent<ArcBullet>().damage = value;
    }

	// Update is called once per frame
	void Update () {
        if (IsSelected() && Input.GetMouseButtonDown(0)) SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);

        Rotate();
    }
}
