using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;

    public float damage1 = 4;
    public float damage2 = 8;
    private int aleatorio;
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

    void OnCollisionEnter(Collision collider) // O DANO � CAUSADO AO INIMIGO COLIDIR COM O JOGADOR
    {
        if (collider.gameObject.tag == "Player")
        {
            aleatorio = Random.Range(0, 2); // � FEITO UM SORTEIO DE QUAL ATAQUE O INIMIGO IR� USAR

            if (aleatorio == 0) // CONDI��O SE ATAQUE 1
            {
                //player.transform.position = reset.transform.position;
                Debug.Log("Recebeu dano1");
                Dano1();
            }
            else // CONDI��O SE ATAQUE 2
            {
                //player.transform.position = reset.transform.position;
                Debug.Log("Recebeu dano2");
                Dano2();
            }

        }
    }
}
