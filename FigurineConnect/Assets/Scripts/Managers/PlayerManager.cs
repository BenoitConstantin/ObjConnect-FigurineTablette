using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private SoldierUnit soldierUnit;
    private ShooterUnit shooterUnit;
    private GameObject playerBase;
    private WallUnit wallUnit;
    private BombUnit bombUnit;

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
    public float bombForce;
    public float timerBomb;
    public bool crazyExplosion;

    [Header("Wall Unit Config")]
    public float wallHeight;
    public float wallWidth;
    public float wallTimeDuration;
    public float wallTimeCooldown;

    // Use this for initialization
    void Start () {
        soldierUnit = SoldierUnit.Instance;
        shooterUnit = ShooterUnit.Instance;
        wallUnit =  WallUnit.Instance;
        bombUnit = BombUnit.Instance;
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
        if (bombUnit != null) {
            SetBombUnitParams();
        }

        if(playerBase != null) {
            playerBase.GetComponent<DefenceHealth>().maxHealth = health;
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

    void SetBombUnitParams() {
        bombUnit.GetComponent<BombUnit>().timeToExplode = timerBomb;
        bombUnit.GetComponent<BombUnit>().explosionArea.GetComponent<BombExplosionArea>().crazyExplosion = crazyExplosion;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
