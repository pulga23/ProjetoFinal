using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent enemy; //robot as navmesh agent
    Transform target; //player's position is the target

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform; //FPS controller has the tag player so we get that transform
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = target.position; // enemy destination is player's position
    }
}
