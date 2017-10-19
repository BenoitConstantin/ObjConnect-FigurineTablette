using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{

    public float maxHealth = 50;
    public float currentHealth = 0; 
    public int attack = 10;
    public float attackCooldown = 1.8f;
    private float timeUntilNextAttack = 0;
    public Vector3 goal;
    private GameObject attackPoint;
    private bool attacking = false;
    public GameObject healthBar;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        goal = FindNextNode();
        agent.destination = goal;
        attackPoint = GameObject.FindGameObjectWithTag("Defence");
    }

    private void LateUpdate() {
        /*Vector3 rotation = Vector3.zero;
        transform.localRotation = Quaternion.Euler(rotation);*/
    }
    
    private void Update()
    {
        if (Vector3.Distance(transform.position,goal) < nodeBuffer)
        {
            goal = FindNextNode();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            if (goal != Vector3.zero)
                agent.destination = goal;
            else {
                agent.destination = attackPoint.transform.position;
                attacking = true;
            }
        }

        if (attacking)
        {
            if (timeUntilNextAttack <= 0)
            {
                attackPoint.GetComponent<DefenceHealth>().currentHealth -= attack;
                timeUntilNextAttack = attackCooldown;
            }
            timeUntilNextAttack -= 1 * Time.deltaTime;
        }

        
    }

    public void UpdateHealthBar(int health) {
        currentHealth = health;
        float healthBarScale = currentHealth / maxHealth;
        //healthBar.transform.localScale = new Vector3(healthBarScale, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    private int nodeBuffer = 200;

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

