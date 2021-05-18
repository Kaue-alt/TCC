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


    //Teste para alterar cor do player ao receber dano
    public bool recebeuDano;
    public Color corInicial;
    Material materialPlayer;

    public float tempoDeEsperaaa = 2f;

    void Start()
    {
        vidaEnemyScript = FindObjectOfType<vidaEnemy>(); // CHAMANDO O SCRIPT "vidaEnemy"
        colliderArma = GetComponent<CapsuleCollider>();

        //Teste para alterar cor do player ao receber dano
        recebeuDano = false;
        Debug.Log(recebeuDano);
        materialPlayer = GetComponent<MeshRenderer>().material;
        materialPlayer.color = corInicial;
    }


    // ------------------------------------ ATAQUES PLAYER -----------------------------------------
    public void Dano1(GameObject enem)
    {
        recebeuDano = true;
        enem.GetComponent<vidaEnemy>().life -= damage1; // REFERENCIA O OBJETO QUE FOI CRIADO A PARTIR DO COLLIDER DO INIMIGO

        //Teste para alterar cor do player ao receber dano       
        if (recebeuDano == false)
        {
            materialPlayer.color = corInicial;
            Debug.Log("corNORMAL");
        }
        else
        {
            materialPlayer.color = Color.red;
            recebeuDano = false;
            Debug.Log(recebeuDano);
            Debug.Log("corVERMELHA");
            StartCoroutine("DeixarVerdadeira");
        }
    }

    public IEnumerator DeixarVerdadeira()
    {
        yield return new WaitForSeconds(tempoDeEsperaaa);
        recebeuDano = true;
        materialPlayer.color = corInicial;
        Debug.Log(recebeuDano);
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

        //Teste para alterar cor do player ao receber dano
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
