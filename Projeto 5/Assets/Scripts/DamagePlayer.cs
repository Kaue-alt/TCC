using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    vidaEnemy vidaEnemyScript;

    public float damage1;
    public GameObject enemy;
    public CapsuleCollider colliderArma;

    void Start()
    {
        vidaEnemyScript = FindObjectOfType<vidaEnemy>(); // CHAMANDO O SCRIPT "vidaEnemy"
        colliderArma = GetComponent<CapsuleCollider>();
    }


    // ------------------------------------ ATAQUES PLAYER -----------------------------------------
    public void Dano1(Collider enem)
    {
            vidaEnemyScript.life -= damage1;
    }

    // -----------------------------------------------------------------------------------------------

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            colliderArma.isTrigger = true;
        }
        else
        {
            colliderArma.isTrigger = false;
        }
           
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            Dano1(other);
            Debug.Log("Inimigo Recebeu dano1");
            Debug.Log(other);
                
        }
    }
}
