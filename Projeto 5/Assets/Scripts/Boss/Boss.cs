using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;

    //private Transform posicaoDoJogador;
    public float velocidadeBoss;
    public float campoPercepcao;

    public float danoCorteRapido;
    public float danoCortePuxao;

    private Transform posicaoDoJogador;
    private Transform posicaoDoBoss;
    //public GameObject player;
    //private posicaoJogador;

    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posicaoDoBoss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        //posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform.position;
        //posicaoJogador = player.transform.position 
    }

    void Update()
    {
        //transform.Translate(Vector2.right * velocidadeBoss * )
        if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 5) //NAO FUNCIONA
        {
            Debug.Log("teste 1: Dboss < 5");
        }
        if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 5) //FUNCIONA
        {
            Debug.Log("teste 1: Dboss > 5");
        }
        //Compara em relação ao mapa??
        if (Vector2.Distance(transform.position, posicaoDoJogador.position) < 5)
        {
            Debug.Log("teste 2: D < 5");
        }
        if (Vector2.Distance(posicaoDoJogador.position, transform.position) < 10)
        {
            Debug.Log("teste 3: D < 10");
        }
        if (Vector2.Distance(posicaoDoJogador.position, transform.position) > 10)
        {
            Debug.Log("teste 4: D > 10");
        }

    }

    public  void corteRapido ()
    {

    }

    private void cortePuxao()
    {
        if (posicaoDoJogador )
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            corteRapido();
        }
    }
}
