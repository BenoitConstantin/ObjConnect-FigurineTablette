using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    public float life;
    private float currentDamage;
    private bool cycleDamage;
    [Header("Damage Config")]
    public float invincibleTime;
    public float currentInvincibleTime;
    public bool recieveDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (recieveDamage) {
            currentInvincibleTime += Time.deltaTime;
            if (currentInvincibleTime > invincibleTime) {
                currentInvincibleTime = 0;
                FinishDamage();
                if (cycleDamage) SetLife(currentDamage, cycleDamage);
            }
        }
	}

    public void SetLife(float delta, bool cycleAttack) {
        
        if (!recieveDamage) {
            recieveDamage = true;
            cycleDamage = cycleAttack;
            currentDamage = delta;
            life -= currentDamage;
            GetComponentInChildren<Animator>().SetTrigger("Damage");
            if (life <= 0) {
                Debug.Log("Enemy destroyed");
                Destroy(gameObject);
            }
        }
    }

    public void FinishDamage() {
        recieveDamage = false;
        currentInvincibleTime = 0;
        GetComponentInChildren<Animator>().SetTrigger("FinishDamage");
    }
}
