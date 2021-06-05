using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    vidaEnemy vidaEnemyScript;
    FeedbackEnemy fbEnemyScript;

    public float damage1;
    //public GameObject enemy;
    public CapsuleCollider colliderArma;


    void Start()
    {
        vidaEnemyScript = FindObjectOfType<vidaEnemy>(); // CHAMANDO O SCRIPT "vidaEnemy"
        fbEnemyScript = FindObjectOfType<FeedbackEnemy>(); // CHAMANDO O SCRIPT "FeedbackEnemy"
        colliderArma = GetComponent<CapsuleCollider>();
    }


    // ------------------------------------ ATAQUES PLAYER -----------------------------------------
    public void Dano1(GameObject enem)
    {
        enem.GetComponent<vidaEnemy>().life -= damage1; // REFERENCIA O OBJETO QUE FOI CRIADO A PARTIR DO COLLIDER DO INIMIGO

        enem.GetComponent<FeedbackEnemy>().damage = true; // ATIVA MUDANÇA DE COR DO INIMIGO ACERTADO
    }

    // -----------------------------------------------------------------------------------------------

    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag ("Enemy"))
        {
            GameObject enemyIns = col.gameObject; // ASSOCIA O COLLIDER DO INIMIGO AO QUE ESTÁ SENDO ATACADO REALMENTE
            Dano1(enemyIns);
            Debug.Log("Inimigo Recebeu dano1");
        }
    }
}
