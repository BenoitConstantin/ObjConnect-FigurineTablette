using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour {

    public bool test;
    public bool inGame { get; private set; }
    public float actionTime;
    [Range(0, 360)]
    public float rotation;
    private bool selected;
    // Use this for initialization
    void Start () {
        inGame = false;
    }

    public bool IsSelected() {
        return selected;
    }

    public void SetUnitSelection(bool sel) {
        selected = sel;
    }

	// Update is called once per frame
	protected virtual void Update () {
        if (IsSelected() && Input.GetMouseButtonDown(0)) {
            SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);
            Rotate();
        }
        
    }

    void OnMouseDown() {
        if (test) {
            SendMessageUpwards("UnitSelection");
            selected = true;
        }
    }
    
    public void Rotate() {

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void SetNewPosition(float posX, float posY) {   
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, 864));
    }


}
