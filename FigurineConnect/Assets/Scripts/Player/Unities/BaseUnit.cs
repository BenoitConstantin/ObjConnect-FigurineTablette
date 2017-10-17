using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour {

    public bool inGame { get; private set; }
    public float actionTime;
    [Range(0, 360)]
    public float rotation;
    private Camera mainCamera;
    // Use this for initialization
    void Start () {
        inGame = false;
        
    }

	public void SetCamera() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

	// Update is called once per frame
	void Update () {
        Rotate();
	}
    
    public void Rotate() {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void SetNewPosition(float posX, float posY) {
       
        transform.position = mainCamera.ScreenToWorldPoint(new Vector3(posX, posY, 10));
    }
}
