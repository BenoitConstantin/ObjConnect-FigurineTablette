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
	void Update () {
        if(test)
        Rotate();
        
	}

    void OnMouseDown() {
        if (test) {
            SendMessageUpwards("UnitSelection");
            selected = true;
        }
    }
    
    public void Rotate() {
        //Vector3 target = transform.localPosition + transform.forward * 10;
        //Vector3.
        /*Quaternion quart = Quaternion.Euler(new Vector3(rotation,rotation,rotation));
        Debug.Log(quart);
        quart.Set(0, 0, quart.z, quart.w);
        transform.rotation = quart;*/

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void SetNewPosition(float posX, float posY) {   
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, 864));
    }
}
