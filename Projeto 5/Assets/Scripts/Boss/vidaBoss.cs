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

    //Pensamento
    public GameObject painelDialogoSozinho;
    public GameObject iconePlayer;
    public bool pensamentoTrueFalse = true;
    public GameObject _textPensamento;
    public Fade fadeScript;


    private void Start()
    {
        _textPensamento.SetActive(true);

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            dead++;
            //GetComponent<Animator>().SetInteger("Death", dead);

            bossMorto = true;
            //StartCoroutine(aparecerPensamento());

        }
        if (bossMorto == true)
        {
            bossMorto = false;
            StartCoroutine(enemyDeath());
        }
    }

    IEnumerator enemyDeath()
    {
        //animaBoss.SetBool("bDeath", true);

        yield return new WaitForSecondsRealtime(1);
        painelDialogoSozinho.SetActive(true);
        iconePlayer.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        //fadeScript.Transition("frenteLab");
        /*if(pensamentoTrueFalse == true)
        {
            painelDialogoSozinho.SetActive(false);
            iconePlayer.SetActive(false);
            pensamentoTrueFalse = false;
        }
        */
        yield return new WaitForSecondsRealtime(1);
        //audioSourceBoss.Play();
    }

    /*IEnumerator aparecerPensamento()
    {
        yield return new WaitForSecondsRealtime(2);
        painelDialogoSozinho.SetActive(true);
        iconePlayer.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        painelDialogoSozinho.SetActive(false);
        iconePlayer.SetActive(false);
        pensamentoTrueFalse = false;
    }
    */
}
