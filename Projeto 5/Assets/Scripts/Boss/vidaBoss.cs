using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vidaBoss : MonoBehaviour
{
    public float life = 100f;
    private int dead = 0;

    public AudioSource audioSourceBoss;

    private GameObject player;
    public bool bossMorto = false;
    //private GameObject player;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (life <= 0f)
        {
            dead++;
            //GetComponent<Animator>().SetInteger("Death", dead);

            StartCoroutine(enemyDeath(2.0f));
            bossMorto = true;

        }
        if (bossMorto == true)
        {
            bossMorto = false;
        }
    }

    IEnumerator enemyDeath(float tempo)
    {
        //GetComponent<Animator>().SetInteger("Death", dead);;
        yield return new WaitForSeconds(tempo);
        //audioSourceBoss.Play();
        Destroy(gameObject);
    }
}
