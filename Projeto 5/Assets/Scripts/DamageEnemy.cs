using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DamageEnemy : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;

    public float damage1;
    public float damage2;
    private int aleatorio;
    private bool canDmg = true;
    public GameObject player;

    public float waitAttack;
    private float speedEnemy;
    
    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>(); // CHAMANDO O SCRIPT "vidaPlayer"

        speedEnemy = GetComponent<NavMeshAgent>().speed;
    }


    // ------------------------------------ ATAQUES INIMIGO -----------------------------------------
    public void Dano1()
    {
        vidaPlayerScript.life -= damage1;

    }

    public void Dano2()
    {
        vidaPlayerScript.life -= damage2;

    }
    // -----------------------------------------------------------------------------------------------
    
    void Update()
    {

    }

    void OnCollisionEnter(Collision collider) // O DANO É CAUSADO AO INIMIGO COLIDIR COM O JOGADOR
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(travarMov(waitAttack));
        }
        else
        {
            GetComponent<Animator>().SetInteger("Attack", 0); // RESETA CONTADOR DA ANIMAÇÃO DO ATAQUE
        }
    }

    IEnumerator travarMov(float tempo)
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().speed = 0;

        aleatorio = Random.Range(0, 2); // É FEITO UM SORTEIO DE QUAL ATAQUE O INIMIGO IRÁ USAR

            if (aleatorio == 0) // CONDIÇÃO SE ATAQUE 1
            {
                GetComponent<Animator>().SetInteger("Attack", 1); // ATIVA ANIMAÇÃO DO ATAQUE 1

                if (canDmg) // LIMITA UM DANO CAUSADO POR ANIMAÇÃO DE ATAQUE
                {
                    Dano1();
                    Debug.Log("Recebeu dano1");

                    canDmg = false;
                }
            }
            else // CONDIÇÃO SE ATAQUE 2
            {
                GetComponent<Animator>().SetInteger("Attack", 2); // ATIVA ANIMAÇÃO DO ATAQUE 2

                if (canDmg) // LIMITA UM DANO CAUSADO POR ANIMAÇÃO DE ATAQUE
                {
                    Dano2();
                    Debug.Log("Recebeu dano2");

                    canDmg = false;
                }
            }

        yield return new WaitForSeconds(tempo);
        GetComponent<NavMeshAgent>().isStopped = false;
        GetComponent<NavMeshAgent>().speed = speedEnemy;
    }

    public void liberarDano() // LIBERA INIMIGO PARA CAUSAR DANO NOVAMENTE, NO FIM DA ANIMAÇÃO
    {
        canDmg = true;
        GetComponent<Animator>().SetInteger("Attack", 0);
    }
}
