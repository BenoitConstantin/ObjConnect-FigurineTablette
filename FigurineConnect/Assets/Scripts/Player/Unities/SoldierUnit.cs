using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUnit : BaseUnit {

    public SpriteRenderer attackSprite;
    
	// Use this for initialization
	void Start () {
        SetCamera();
        attackSprite.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (IsSelected() && Input.GetMouseButtonDown(0)) SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);

        Rotate();
    }
}
