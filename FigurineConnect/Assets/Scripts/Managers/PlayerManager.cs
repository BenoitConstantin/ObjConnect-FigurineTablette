using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private GameObject soldierUnit;
    private GameObject shooterUnit;

    [Header("General Config")]
    public int life;
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
        if (soldierUnit != null) {
            SetSoldierParams();
        }
        if(shooterUnit != null) {
            SetShooterParams();
        }
	}
	
    void SetSoldierParams() {
        soldierUnit.GetComponent<SoldierUnit>().SetDamageAttack(soldierDamage);
    }

    void SetShooterParams() {
        soldierUnit.GetComponent<ShooterUnit>().cadence = shooterCadence;
        soldierUnit.GetComponent<ShooterUnit>().SetDamageAttack(shooterDamage);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
