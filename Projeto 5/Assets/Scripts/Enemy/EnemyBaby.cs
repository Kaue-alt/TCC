using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaby : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float distance;

    public Transform ProjetilPrefab;
    Transform shotSpawn;
    Transform enemyBaby;

    public GameObject enemy;


    void Awake()
    {
        shotSpawn = transform.Find("shotSpawn");
        shotSpawn = transform.Find("enemyBaby");

        
    }

    void Start()
    {
        // Inimigo encontra o player pela tag
        player = GameObject.FindWithTag("Player");

        //enemy.transform.Rotate(-90.0f, 0.0f, -90.0f);
    }


    void Update()
    {
        // ======================================= MOVIMENTAÇÃO DOS INIMIGOS =========================================

        // Segue o jogador a partir de uma determinada distância
        if (Vector3.Distance(transform.position, player.transform.position) <= distance)
        {
            agent.destination = player.transform.position;
            agent.isStopped = false;

            //GetComponent<Animator>().SetBool("bRun", true);
            //GetComponent<Animator>().SetBool("bIdle", false);

            //ShootBullet();
        }

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attacking")) // DEIXA O INIMIGO PARADO ENQUANTO ATACA
        {
            agent.isStopped = true;
        }

        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            //GetComponent<Animator>().SetBool("bRun", false);
           //GetComponent<Animator>().SetBool("bIdle", true);
        }

        // =============================================================================================================
    }

    /*void ShootBullet()
    {
        Transform projetilobj = Instantiate(ProjetilPrefab, shotSpawn.position, shotSpawn.rotation);
        Destroy(projetilobj.gameObject, 8f);

        projetilobj.GetComponent<Projetil>().SetDirection(enemyBaby.GetForwardDirection());
    }*/
}
