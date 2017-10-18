using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    [Range(0,1)]
    public float scaleTime = 1;
    private Vector3 position;
    private Rigidbody2D rigid;
    private Vector3 limitInf;
    private Vector3 limitSup;
    private Vector3 forward;
    private int damage;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        GameObject limits = GameObject.FindGameObjectWithTag("Limits");
        if (limits != null) {
            limitInf = limits.transform.Find("Min").localPosition;
            limitSup = limits.transform.Find("Max").localPosition;
        } else {
            Debug.LogError("Please create and tag a Limits GameObject with Min and Max GameObjects to define the map limits");
        }
	}

    private void Update() {
        Time.timeScale = scaleTime;
        Vector3 pos = transform.localPosition;
        if(pos.x<limitInf.x || pos.y<limitInf.y || pos.x> limitSup.x || pos.y> limitSup.y) {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction, float angle) {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //Debug.Log(direction);
        this.direction = Vector3.Normalize(direction);
        //this.forward = forward;
    }
    // Update is called once per frame
    void FixedUpdate () {
        Move();
	}
    void Move() {
        rigid.MovePosition(transform.position + direction * (Time.deltaTime * speed*100));
    }

    public void SetBulletDamage(int value) {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        if (enemy != null) {
            enemy.SetLife(damage,false);
            Destroy(gameObject);
        }
    }
}
