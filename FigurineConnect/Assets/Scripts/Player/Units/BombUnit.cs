using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnit : BaseUnit {

    public static BombUnit Instance;

    public Transform renderBomb;
    public GameObject explosionFX;
    public GameObject explosionArea;
    public float timeToExplode;
    private bool startTick = false;
    // Use this for initialization

    void Awake()
    {
        Instance = this;
    }

    void Start() {
        //activationArea.SetActive(false);
        //Invoke("StartExplosion", timeToExplode);
    }

    public void StartExplosion() {
        InstanceExplosionFX();
        
    }

    public void FinishExplosion() {
        if(test) renderBomb.GetComponent<SpriteRenderer>().enabled = true;
        explosionArea.GetComponent<BombExplosionArea>().hasExploded = false;
        explosionArea.GetComponent<Collider>().enabled = false;
    }

    public void InstanceExplosionFX() {
        SoundManager.Instance.PlayBombExplosionSFX();
        explosionArea.GetComponent<BombExplosionArea>().ExplosionForce();
        explosionArea.GetComponent<BombExplosionArea>().hasExploded = true;
        explosionArea.GetComponent<Collider>().enabled = true;
        GameObject exFX = Instantiate(explosionFX);
        exFX.transform.parent = transform;
        exFX.transform.localPosition = Vector3.zero;
        renderBomb.GetComponent<SpriteRenderer>().enabled = false;
        startTick = false;
        
    }

    Vector3 lastTransformPosition = Vector3.zero;
    private void LateUpdate() {
        if (lastTransformPosition != transform.position) {
            if (!startTick) {
                renderBomb.GetComponent<SpriteRenderer>().enabled = true;
                SoundManager.Instance.PlayBombPlaceSFX();
                startTick = true;
                Invoke("StartExplosion", timeToExplode);
            }
        }
        lastTransformPosition = transform.position;
    }
}
