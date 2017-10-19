using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceHealth : MonoBehaviour {
    public float maxHealth = 200;
    public float currentHealth = 0;
    public GameObject healthBar;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        float healthBarScale = currentHealth / maxHealth;

        healthBar.transform.localScale = new Vector3(healthBarScale, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
