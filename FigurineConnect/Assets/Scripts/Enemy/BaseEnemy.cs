using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Nav Mesh Agent
public class BaseEnemy : MonoBehaviour {

    protected uint health = 50;
    protected uint attack = 10;
    protected Vector2 target;
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
