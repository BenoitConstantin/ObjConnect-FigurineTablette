using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{

    protected uint health = 50;
    protected uint attack = 10;
    protected Vector2 target;
    public Vector3 goal;
    private Vector3 attackPoint;
    private bool attacking = false; 

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        goal = FindNextNode();
        agent.destination = goal;
        attackPoint = GameObject.FindGameObjectWithTag("Defence").transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,goal) < 1)
        {
            goal = FindNextNode();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            if (goal != Vector3.zero)
                agent.destination = goal;
            else {
                agent.destination = attackPoint;
            }
        }

        if (attacking)
        {
            //Deal damage to defence. 
        }
    }

    private int nodeBuffer = 2;

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

