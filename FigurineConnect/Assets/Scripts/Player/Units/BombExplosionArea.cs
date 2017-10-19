using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosionArea : MonoBehaviour {

    private Vector3 lastForce;
    public float multiplierForceX;
    public float multiplierForceY;
    public bool hasExploded = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExplosionForce() {
        Vector3 explosionPos = transform.position;
        float radius = transform.localScale.x / 2;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders) {
            if (hit.GetComponent<HealthEnemy>())
                hit.GetComponent<Rigidbody>().AddExplosionForce(multiplierForceX, explosionPos, radius, 6.0F,ForceMode.Impulse);

        }
    }

    void OnTriggerEnter(Collider collision) {
        //if (startExplosion) 
        /*if (hasExploded) {
            HealthEnemy e = collision.GetComponent<HealthEnemy>();
            if (e != null) {
                Vector3 playerDirection = e.transform.position - transform.position;
                //playerDirection = playerDirection.normalized;
                //playerDirection.x *= multiplierForceX;
               // playerDirection.y *= multiplierForceY;
                Debug.Log("PlayerDirection: " + playerDirection);
                collision.GetComponent<Rigidbody>().AddExplosionForce(multiplierForceX * playerDirection.magnitude, transform.position, 30,);
                Debug.Log("Applying bomb force");
                //collision.GetComponent<Rigidbody>().AddForce(-BombScript.LastForce);
            }
        }*/
    }
}
