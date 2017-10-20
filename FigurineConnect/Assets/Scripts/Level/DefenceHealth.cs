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

    public void UpdateHealth(float value) {
        currentHealth += value;
        GameObject.Find("Face").GetComponent<Animator>().SetTrigger("TakeDamage");
        if (currentHealth <= 0) {
            SoundManager.Instance.PlayEndGameSFX(false);
            GameManager.Instance.EndParty(false);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float healthBarScale = currentHealth / maxHealth;

        healthBar.transform.localScale = new Vector3(healthBarScale, healthBar.transform.localScale.y, healthBar.transform.localScale.z);         
    }
}
