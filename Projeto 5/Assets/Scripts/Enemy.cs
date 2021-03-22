using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float distance = 3;
    
    void Start()
    {
        // Inimigo encontra o player pela tag
        player = GameObject.FindWithTag("Player");
        
    }

    
    void Update()
    {
        // Segue o jogador a partir de uma determinada distância
        if (Vector3.Distance (transform.position, player.transform.position) < distance)
        {
            agent.destination = player.transform.position;
        }
    }
}
