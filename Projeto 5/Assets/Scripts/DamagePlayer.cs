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
    //  public Material[] material;
    //  public int x;
    //  Renderer rend;

    public Color corInicial;
    Material materialPlayer;
    float cronometro;
    public float tempoTroca = 1;
    public float tempoDeEsperaaa = 1f;

    void Start()
    {
        vidaEnemyScript = FindObjectOfType<vidaEnemy>(); // CHAMANDO O SCRIPT "vidaEnemy"
        colliderArma = GetComponent<CapsuleCollider>();
        cronometro = 0;
        //Teste para alterar cor do player ao receber dano
        //   x = 0;
        //   rend = GetComponent<Renderer>();
        //   rend.enabled = false;
        //   rend.sharedMaterial = material[x];

        materialPlayer = GetComponent<MeshRenderer>().material;
        materialPlayer.color = corInicial;
    }


    // ------------------------------------ ATAQUES PLAYER -----------------------------------------
    public void Dano1(GameObject enem)
    {

        enem.GetComponent<vidaEnemy>().life -= damage1; // REFERENCIA O OBJETO QUE FOI CRIADO A PARTIR DO COLLIDER DO INIMIGO

        //Teste para alterar cor do player ao receber dano
        //   rend.enabled = true;


        StartCoroutine(naoSei(tempoDeEsperaaa));
            materialPlayer.color = corInicial;
 
            materialPlayer.color = Color.red;
 
    }
    public IEnumerator naoSei (float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);
    }

    // -----------------------------------------------------------------------------------------------

    void Update()
    {
        cronometro += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            colliderArma.isTrigger = true;
        }
        else
        {
            colliderArma.isTrigger = false;
        }

        //Teste para alterar cor do player ao receber dano
     //   rend.sharedMaterial = material[x];
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
