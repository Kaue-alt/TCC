using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaby : MonoBehaviour
{
    NavMeshAgent agent;
    Transform goal;
    public float distTiro;
    public GameObject vomito;
    public Transform shootPoint;
    bool isShooting;
    public GameObject enemyBaby;

    private Animator animaBaby;


    void Awake()
    {
        

        
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        animaBaby = enemyBaby.GetComponent<Animator>();

        animaBaby.SetBool("bIdle", true);

        
    }


    void Update()
    {
        // ======================================= MOVIMENTAÇÃO DO INIMIGO =========================================

        
        float distance = Vector3.Distance(transform.position, goal.position);
        if(distance <= distTiro)
        {
            agent.destination = goal.transform.position;

            animaBaby.SetBool("bRun", true);
            animaBaby.SetBool("bIdle", false);

            if (!isShooting)
            {
                InvokeRepeating("ShootBullet", 0f, 0.5f);
                isShooting = true;
                Destroy(vomito.gameObject, 6f);
            }
            
        }
        else
        {
            CancelInvoke("ShootBullet");
            isShooting = false;
            animaBaby.SetBool("bRun", false);
            animaBaby.SetBool("bIdle", true);
        }
        
       
            
     }
        
        // =============================================================================================================
 

    void ShootBullet()
    {
        Instantiate(vomito, shootPoint.position, shootPoint.rotation);
        //Destroy(vomito.gameObject, 6f);
 
    }
}
