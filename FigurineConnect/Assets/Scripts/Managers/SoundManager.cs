using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SimpleSingleton<SoundManager> {
    public AudioSource[] bossHitSFX;
    public AudioSource[] enemyHitSFX;
    public AudioSource[] rayonShootSFX;
    public AudioSource[] bombSFX;

    public AudioSource bossDeathSFX;
    public AudioSource enemyDeathSFX;
    // Use this for initialization
    void Start() {
        GameObject bossHit = GameObject.Find("BossHit");
        GameObject enemyHit = GameObject.Find("EnemyHit");
        GameObject rayonShoot = GameObject.Find("RayonShoot");
        GameObject enemyDeath = GameObject.Find("EnemyDeath");
        GameObject bomb = GameObject.Find("Bomb");

        if (bossHit != null) {
            bossHitSFX = bossHit.GetComponents<AudioSource>();
        }
        if (enemyHit != null) {
            enemyHitSFX = enemyHit.GetComponents<AudioSource>();
        }
        if (rayonShoot != null) {
            rayonShootSFX = rayonShoot.GetComponents<AudioSource>();
        }
        if (enemyDeath != null) {
            bossDeathSFX = enemyDeath.GetComponents<AudioSource>()[0];
            enemyDeathSFX = enemyDeath.GetComponents<AudioSource>()[1];
        }
        if (bomb != null) {
            bombSFX = bomb.GetComponents<AudioSource>();
        }
    }

    public void PlayBossHitSFX() {
        if (bossHitSFX.Length >= 0) {
            int random = Random.Range(0, bossHitSFX.Length);
            bossHitSFX[random].Play();
        }
    }

    public void PlayEnemysHitSFX() {
        if (enemyHitSFX.Length >= 0) {
            int random = Random.Range(0, enemyHitSFX.Length);
            enemyHitSFX[random].Play();
        }
    }

    public void PlayRayonShootSFX() {
        if (rayonShootSFX.Length >= 0) {
            int random = Random.Range(0, rayonShootSFX.Length);
            rayonShootSFX[random].Play();
        }
    }

    public void PlayBossDeathSFX() {
        bossDeathSFX.PlayDelayed(0.25f);
    }

    public void PlayEnemyDeathSFX() {
        enemyDeathSFX.PlayDelayed(0.25f);
    }

    public void PlayBombPlaceSFX() {
        bombSFX[0].Play();
    }

    public void PlayBombExplosionSFX() {
        bombSFX[1].Play();
    }

    public void PlayClickSFX() {

    }
}