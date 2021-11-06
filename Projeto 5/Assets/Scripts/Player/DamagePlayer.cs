using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    vidaEnemy vidaEnemyScript;
    vidaBoss vidaBossScript;
    FeedbackEnemy fbEnemyScript;

    public float damage1;
    //public GameObject enemy;
    public CapsuleCollider colliderArma;

    void Start()
    {
        vidaEnemyScript = FindObjectOfType<vidaEnemy>(); // CHAMANDO O SCRIPT "vidaEnemy"
        vidaBossScript = FindObjectOfType<vidaBoss>(); // CHAMANDO O SCRIPT "vidaBoss"
        fbEnemyScript = FindObjectOfType<FeedbackEnemy>(); // CHAMANDO O SCRIPT "FeedbackEnemy"
    }

    // ------------------------------------ ATAQUES PLAYER -----------------------------------------
    public void Dano1(GameObject enem)
    {
        enem.GetComponent<vidaEnemy>().life -= damage1; // REFERENCIA O OBJETO QUE FOI CRIADO A PARTIR DO COLLIDER DO INIMIGO

        enem.GetComponent<FeedbackEnemy>().damage = true; // ATIVA MUDAN�A DE COR DO INIMIGO ACERTADO
    }
    
    // -----------------------------------------------------------------------------------------------
    public void DanoBoss(GameObject goBoss)
    {
        goBoss.GetComponent<vidaBoss>().life -= damage1; // REFERENCIA O OBJETO QUE FOI CRIADO A PARTIR DO COLLIDER DO BOSS

        goBoss.GetComponent<FeedbackEnemy>().damage = true; // ATIVA MUDAN�A DE COR DO BOSS
    }


    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag ("Enemy"))
        {
            GameObject enemyIns = col.gameObject; // ASSOCIA O COLLIDER DO INIMIGO AO QUE EST� SENDO ATACADO REALMENTE
            Dano1(enemyIns);
        }
        if (col.gameObject.CompareTag("Boss"))
        {
            GameObject bossIns = col.gameObject; // ASSOCIA O COLLIDER DO INIMIGO AO QUE EST� SENDO ATACADO REALMENTE
            DanoBoss(bossIns);
        }
    }
}
