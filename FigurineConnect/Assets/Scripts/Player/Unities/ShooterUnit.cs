using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterUnit : BaseUnit {

    public float cadence; //Shoot frequence
    public GameObject bullet;
    public Transform head;
    private float currentTime;
    private Transform bulletLayer;
	// Use this for initialization
	void Start () {
        bulletLayer = GameObject.FindGameObjectWithTag("BulletLayer").transform;
        SetCamera();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);
        }
        currentTime += Time.deltaTime;
        if (currentTime > cadence) {
            Shoot();
            currentTime = 0;
        }
        Rotate();
	}

    void Shoot() {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.parent = (bulletLayer != null)? bulletLayer: transform.parent;
        newBullet.transform.localPosition = transform.localPosition;
        newBullet.GetComponent<SimpleBullet>().SetDirection(head.position - transform.position, rotation);
    }
}
