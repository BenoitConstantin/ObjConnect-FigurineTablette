using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFace : MonoBehaviour {

    public static MoonFace current;

    public float hurtTime = 1.0f;

    SpriteRenderer myFace;

    public Sprite normalFace;
    public Sprite hurtFace;

    void Start() {
        current = this;
        myFace = GetComponent<SpriteRenderer>();
        myFace.sprite = normalFace;
    }

    public IEnumerator TakeDamage() {
        myFace.sprite = hurtFace;
        yield return new WaitForSeconds(hurtTime);
        myFace.sprite = normalFace;
    }
}
