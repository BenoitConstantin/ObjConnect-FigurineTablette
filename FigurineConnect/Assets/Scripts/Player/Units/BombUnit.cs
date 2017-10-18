using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnit : BaseUnit {

    public Transform renderBomb;
    public GameObject explosionArea;
    public GameObject activationArea;
    public float timeToExplode;
    // Use this for initialization

    void Start() {
        //activationArea.SetActive(false);
        SetCamera();
        Invoke("StartExplosion", timeToExplode);
    }

    public void StartExplosion() {
        renderBomb.Find("Explosion").gameObject.SetActive(true);
        renderBomb.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }
}
