using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBullet : MonoBehaviour {

    public int damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        if (enemy != null) {
            enemy.SetLife(damage);
        }
    }
}
