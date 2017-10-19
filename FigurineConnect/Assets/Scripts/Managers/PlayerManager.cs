using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private GameObject soldierUnit;
    private GameObject shooterUnit;
    private GameObject playerBase;
    private GameObject wallUnit;

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
    public int bombTimer;

    [Header("Wall Unit Config")]
    public float wallHeight;
    public float wallWidth;
    public float wallTimeDuration;
    public float wallTimeCooldown;

    // Use this for initialization
    void Start () {
        soldierUnit = GameObject.Find("SoldierUnit");
        shooterUnit = GameObject.Find("ShooterUnit");
        wallUnit = GameObject.Find("WallUnit");

        playerBase = GameObject.FindGameObjectWithTag("PlayerBase");
        if (soldierUnit != null) {
            SetSoldierParams();
        }
        if(shooterUnit != null) {
            SetShooterParams();
        }
        if (wallUnit != null)
        {
            SetWallParams();
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

    void SetWallParams()
    {
        wallUnit.GetComponent<WallUnit>().SetWallHeight(wallHeight);
        wallUnit.GetComponent<WallUnit>().SetWallWidth(wallWidth);
        wallUnit.GetComponent<WallUnit>().SetWallDuration(wallTimeDuration);
        wallUnit.GetComponent<WallUnit>().SetWallCooldown(wallTimeCooldown); 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
