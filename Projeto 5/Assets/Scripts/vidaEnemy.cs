using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vidaEnemy : MonoBehaviour
{
    public float life = 100f;
    private int  dead = 0;

    public AudioSource audioSourceMonster;

    private GameObject player;
    private NavMeshAgent navEnemy;
    public float expValue;

    Enemy enemyScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyScript = GetComponent<Enemy>();
        navEnemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (life <= 0f)
        {
            dead++;
            GetComponent<Animator>().SetInteger("Death", dead);
            StartCoroutine(enemyDeath(2.0f));
        }
    }
    
    IEnumerator enemyDeath(float tempo)
    {
        audioSourceMonster.Play();
        enemyScript.enabled = false;
        navEnemy.enabled = false;
        yield return new WaitForSeconds(tempo);
        Destroy(gameObject);
        player.GetComponent<LevelSystem>().SetExperience(expValue);
    }
}
