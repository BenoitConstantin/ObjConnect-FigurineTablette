using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterUnit : BaseUnit {

    public static ShooterUnit Instance;

    public float cadence; //Shoot frequence
    public GameObject bullet;
    public Transform head;
    private float currentTime;
    private Transform bulletLayer;
    private int bulletDamage;

    public GameObject fx;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        bulletLayer = GameObject.FindGameObjectWithTag("BulletLayer").transform;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        
        currentTime += Time.deltaTime;
        if (currentTime > cadence) {
            Shoot();
            currentTime = 0;
        }
        if (test && IsSelected()) Rotate();
	}

    void Shoot() {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.parent = (bulletLayer != null)? bulletLayer: transform.parent;
        newBullet.transform.position = transform.position;
        //newBullet.GetComponent<SimpleBullet>().SetDirection(head.position - transform.position, rotation);
        newBullet.GetComponent<SimpleBullet>().SetDirection(transform.up, rotation);
        newBullet.GetComponent<SimpleBullet>().SetBulletDamage(bulletDamage);
        //FX
        if (fx != null) {
            //GameObject fxx = Instantiate(fx);
            //fxx.transform.position = head.position;
        }
    }

    public void SetDamageAttack(int value) {
        bulletDamage = value;
    }
}
