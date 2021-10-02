using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PensamentoSozinho : MonoBehaviour
{
    public GameObject _textPensamento;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    public GameObject painelDialogoSozinho;
    public GameObject iconePlayer;

    TransicaoParaODia transicaoParaODia;

    public Text falaSozinho;
    void Start()
    {
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();

        _textPensamento.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Está dentro do Pensamento");
            painelDialogoSozinho.SetActive(true);
            iconePlayer.SetActive(true);
        }
        //SOLUÇÃO TEMPORÁRIA PARA DESATIVAÇÃO
        if(transicaoParaODia.ganchoTransicao >= 120)
        {
            Debug.Log("Cont passou dos 120");
            painelDialogoSozinho.SetActive(false);
            iconePlayer.SetActive(false);
        }



    }
   //void OnTriggerEnter(Collider other)
}


