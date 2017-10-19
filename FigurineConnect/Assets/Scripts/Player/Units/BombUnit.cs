using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnit : BaseUnit {

    public Transform renderBomb;
    public GameObject explosionFX;
    public GameObject explosionArea;
    public float timeToExplode;
    private bool startTick = false;
    // Use this for initialization

    void Start() {
        //activationArea.SetActive(false);
        SetCamera();
        //Invoke("StartExplosion", timeToExplode);
    }

    public void StartExplosion() {
        InstanceExplosionFX();
        
    }

    public void FinishExplosion() {
        renderBomb.GetComponent<SpriteRenderer>().enabled = true;
        explosionArea.GetComponent<BombExplosionArea>().hasExploded = false;
        explosionArea.GetComponent<Collider>().enabled = false;
    }

    public void InstanceExplosionFX() {
        explosionArea.GetComponent<BombExplosionArea>().ExplosionForce();
        explosionArea.GetComponent<BombExplosionArea>().hasExploded = true;
        explosionArea.GetComponent<Collider>().enabled = true;
        GameObject exFX = Instantiate(explosionFX);
        exFX.transform.parent = transform;
        exFX.transform.localPosition = Vector3.zero;
        renderBomb.GetComponent<SpriteRenderer>().enabled = false;
        startTick = false;
        
    }

    // Update is called once per frame
    void Update() {
        
        if (IsSelected() && !startTick && Input.GetMouseButtonDown(0)) {
            
            startTick = true;
            Invoke("StartExplosion", timeToExplode);
            
        }
        if (IsSelected() &&  Input.GetMouseButtonDown(0)) {
            SetNewPosition(Input.mousePosition.x, Input.mousePosition.y);
            Rotate();
        }
        
    }
}
