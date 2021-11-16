using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaby : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float distance;

    public GameObject ProjetilPrefab;
    public Transform shotSpawn;
    //public Transform enemyBaby;

    public GameObject Babyenemy;

    private Animator animaBaby;


    void Awake()
    {
        //shotSpawn = transform.Find("shotSpawn");
        //shotSpawn = transform.Find("enemyBaby");

        
    }

    void Start()
    {
        // Inimigo encontra o player pela tag
        player = GameObject.FindWithTag("Player");
        animaBaby = Babyenemy.GetComponent<Animator>();

        animaBaby.SetBool("bIdle", true);

        
    }


    void Update()
    {
        // ======================================= MOVIMENTAÇÃO DOS INIMIGOS =========================================

        // Segue o jogador a partir de uma determinada distância
        if (Vector3.Distance(transform.position, player.transform.position) <= distance)
        {
            agent.destination = player.transform.position;
            agent.isStopped = false;
            animaBaby.SetBool("bIdle", false);
            animaBaby.SetBool("bRun", true);
            

            ShootBullet();
        }
        //else
        //{
            //animaBaby.SetBool("bRun", false);
            //animaBaby.SetBool("bIdle", true);
        //}

        //if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attacking")) // DEIXA O INIMIGO PARADO ENQUANTO ATACA
        //{
            //agent.isStopped = true;
        //}

        //if (Vector3.Distance(transform.position, player.transform.position) > distance)
        //{
            //GetComponent<Animator>().SetBool("bRun", false);
           //GetComponent<Animator>().SetBool("bIdle", true);
       // }

        // =============================================================================================================
    }

    void ShootBullet()
    {
        Instantiate(ProjetilPrefab, shotSpawn.position, shotSpawn.rotation);
        Destroy(ProjetilPrefab.gameObject, 8f);

        //projetilobj.GetComponent<Projetil>().SetDirection(enemyBaby.GetForwardDirection());
    }
}
