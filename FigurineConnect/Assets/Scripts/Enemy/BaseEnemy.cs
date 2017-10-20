using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{

    //public float maxHealth = 50;
    //public float currentHealth = 0; 
    public int attack = 10;
    public float attackCooldown = 1.8f;
    private float timeUntilNextAttack = 0;
    public Vector3 goal;
    public GameObject attackPoint;
    private bool attacking = false;
    public GameObject healthBar;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
       // currentHealth = maxHealth;
        goal = FindNextNode();
        agent.destination = goal;
        attackPoint = GameObject.FindGameObjectWithTag("Defence");

        GameObject limits = GameObject.FindGameObjectWithTag("Limits");
        if (limits != null) {
            limitInf = limits.transform.Find("Min").localPosition;
            limitSup = limits.transform.Find("Max").localPosition;
        } else {
            Debug.LogError("Please create and tag a Limits GameObject with Min and Max GameObjects to define the map limits");
        }
    }

    private void Update()
    {


        Vector3 pos = transform.localPosition;
        if (pos.x < limitInf.x || pos.y < limitInf.y || pos.x > limitSup.x || pos.y > limitSup.y) {
            GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawnManager>().totalNumberOfEnemies--;
            Destroy(gameObject);
            return;
        }

        if (Vector3.Distance(transform.position,goal) < nodeBuffer)
        {
            goal = FindNextNode();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            if (goal != Vector3.zero)
                agent.destination = goal;
            else
            {
                agent.destination = attackPoint.transform.position;
                attacking = true;
            }
        }

        if (attacking)
        {
            if (timeUntilNextAttack <= 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("Attack");
                if (attackPoint != null && attackPoint.activeSelf) {
                    attackPoint.GetComponent<DefenceHealth>().UpdateHealth(-attack);

                }
              //  if(MoonFace.current!=null) MoonFace.current.TakeDamage();
                
                timeUntilNextAttack = attackCooldown;
            }
            timeUntilNextAttack -= 1 * Time.deltaTime;
        }
    }

    public void UpdateHealthBar(int health) {
       // currentHealth = health;
       // float healthBarScale = currentHealth / maxHealth;
        //healthBar.transform.localScale = new Vector3(healthBarScale, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    private int nodeBuffer = 100;

    public Vector3 limitInf { get; private set; }
    public Vector3 limitSup { get; private set; }

    private Vector3 FindNextNode()
    {
        Vector3 nearestNode = Vector3.zero;

        GameObject[] nodes = GameObject.FindGameObjectsWithTag("PathNode");

        float dist = float.MaxValue;

        for (int i = 0; i < nodes.Length; ++i)
        {
            if (nodes[i].transform.position.y - nodeBuffer > transform.position.y)
            {
                if (Vector3.Distance(transform.position, nodes[i].transform.position) < dist)
                {
                    nearestNode = nodes[i].transform.position;
                    dist = Vector3.Distance(transform.position, nodes[i].transform.position);
                }
            }
        }
        return nearestNode;
    }
}

