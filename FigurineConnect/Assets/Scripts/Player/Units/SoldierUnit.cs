using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : BaseUnit {

    public static SoldierUnit Instance;

    public GameObject arcBullet;


    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
       // arcBullet.GetComponent<SpriteRenderer>().enabled = false;
    }
	
    public void SetDamageAttack(int value) {
        arcBullet.GetComponent<ArcBullet>().damage = value;
    }

	// Update is called once per frame
	void Update () {
        if (IsSelected() && Input.GetMouseButtonDown(0)) {
            SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);
            Rotate();
        }
    }
}
