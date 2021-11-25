using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausaMovimento : MonoBehaviour
{
    Movimentacao scriptMovimentacao;
    dashMove scriptDash;
    Boss scriptBoss;

    public GameObject hudVida, hudDash, hudArmas;

    private bool travaMovimento = true;

    void Start()
    {      
        scriptMovimentacao = FindObjectOfType<Movimentacao>();
        scriptDash = FindObjectOfType<dashMove>();
        scriptBoss = FindObjectOfType<Boss>();
    }

    void Update()
    {
        if (travaMovimento == true)
        {
            StartCoroutine(ativaMovimentos());
            scriptDash.enabled = false;
            scriptMovimentacao.enabled = false;
            Debug.Log("Não se mova!");
        }
        else
        {
            hudVida.SetActive(true);
            hudArmas.SetActive(true);
            hudDash.SetActive(true);
        }
       
    }

    IEnumerator ativaMovimentos()
    {
        yield return new WaitForSecondsRealtime(3);
        travaMovimento = false;
        Debug.Log("Player pode se movimentar!");
    }
}
