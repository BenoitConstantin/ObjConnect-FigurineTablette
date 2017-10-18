using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private GameObject soldierUnit;
    private GameObject shooterUnit;
    private GameObject playerBase;

    [Header("General Config")]
    public int health;
    public float scaleTime;
    public float scaleTimeDuration;

    [Header("Shooter Unit Config")]
    public float shooterCadence;
    public int shooterDamage;

    [Header("Soldier Unit Config")]
    public int soldierDamage;

    [Header("Bomb Unit Config")]
    public int bombDamage;


    // Use this for initialization
    void Start () {
        soldierUnit = GameObject.Find("SoldierUnit");
        shooterUnit = GameObject.Find("ShooterUnit");
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase");
        if (soldierUnit != null) {
            SetSoldierParams();
        }
        if(shooterUnit != null) {
            SetShooterParams();
        }
        if(playerBase != null) {
            playerBase.GetComponent<PlayerBase>().health = health;
        }
	}
	
    void SetSoldierParams() {
        soldierUnit.GetComponent<SoldierUnit>().SetDamageAttack(soldierDamage);
    }

    void SetShooterParams() {
        shooterUnit.GetComponent<ShooterUnit>().cadence = shooterCadence;
        shooterUnit.GetComponent<ShooterUnit>().SetDamageAttack(shooterDamage);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
