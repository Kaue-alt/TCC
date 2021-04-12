using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;

    public float damage1;
    public float damage2;
    private int aleatorio;
    private bool canDmg = true;
    public GameObject player;

    
    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>(); // CHAMANDO O SCRIPT "vidaPlayer"
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
            aleatorio = Random.Range(0, 2); // É FEITO UM SORTEIO DE QUAL ATAQUE O INIMIGO IRÁ USAR

            if (aleatorio == 0) // CONDIÇÃO SE ATAQUE 1
            {
                //player.transform.position = reset.transform.position;

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
                //player.transform.position = reset.transform.position;

                GetComponent<Animator>().SetInteger("Attack", 2); // ATIVA ANIMAÇÃO DO ATAQUE 2

                if (canDmg) // LIMITA UM DANO CAUSADO POR ANIMAÇÃO DE ATAQUE
                {
                    Dano2();
                    Debug.Log("Recebeu dano2");

                    canDmg = false;
                }
            }

        }
        else
        {
            GetComponent<Animator>().SetInteger("Attack", 0); // RESETA CONTADOR DA ANIMAÇÃO DO ATAQUE
        }
    }

    public void liberarDano() // LIBERA INIMIGO PARA CAUSAR DANO NOVAMENTE, NO FIM DA ANIMAÇÃO
    {
        canDmg = true;
        GetComponent<Animator>().SetInteger("Attack", 0);
    }
}
