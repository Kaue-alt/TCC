using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;
    vidaBoss vidaDoBoss;

    //private Transform posicaoDoJogador;
    public float velocidadeBoss;
    public float campoPercepcao;

    public float danoCorteRapido;
    public float danoCortePuxao;

    private Transform posicaoDoJogador;
    private Transform posicaoDoBoss;
    //public GameObject player;
    //private posicaoJogador;

    //Controle de pulo
    public float jumpSpeedUp;
    public float jumpSpeedRight;
    public float jumpSpeedLeft;
    public float jumpSpeedDown;
    public float speedCorte;
    public float speedDashCorte;
    public Rigidbody rigidBodyBoss;

    //Permissões
    private bool podePular = true;
    private bool podeCortar = true;

    //Dano
    public float danoDoCorte;
    public float danoDoCortePesado;
    public float danoDaInvestida;

    void Start()
    {
        //Pegar posição do Player e Boss
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posicaoDoBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        //Invocar Scripts
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();
        vidaDoBoss = FindObjectOfType<vidaBoss>();
    }

    void Update()
    {
        //transform.Translate(Vector2.right * velocidadeBoss * )
        if(vidaDoBoss.life >= 50)
        {
            Debug.Log("Vida acima de 50");
            //Pular para a direita
            if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 10 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                Debug.Log("Jogador - Boss if 1");
                StartCoroutine(puloDireita());
                //rigidBodyBoss.AddForce(Vector3.up * jumpSpeedBoss, ForceMode.VelocityChange);
                //rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRightBoss, ForceMode.VelocityChange);
                StartCoroutine(cooldownPulo());
            }

            //Pular para a esquerda
            if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 10 && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //FUNCIONA
            {
                Debug.Log("Jogador - Boss if 1");
                StartCoroutine(puloEsquerda());
                //rigidBodyBoss.AddForce(Vector3.up * jumpSpeedBoss, ForceMode.VelocityChange);
                //rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRightBoss, ForceMode.VelocityChange);
                StartCoroutine(cooldownPulo());
            }

            //Cortar
            if (podeCortar == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
            {
                StartCoroutine(cooldownCorte());
                corteRapido();
                Debug.Log("cortou!");
            }
        }
        else
        {
            Debug.Log("Vida abaixo de 50, cuidado!");
        }      
    }

    //Controlar direção dos pulos
    IEnumerator puloDireita()
    {
        rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
        yield return new WaitForSecondsRealtime(0.3f);
        rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRight, ForceMode.VelocityChange);
        yield return new WaitForSecondsRealtime(0.5f);
        rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
    }

    IEnumerator puloEsquerda()
    {
        rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
        yield return new WaitForSecondsRealtime(0.3f);
        rigidBodyBoss.AddForce(Vector3.left * jumpSpeedLeft, ForceMode.VelocityChange);
        yield return new WaitForSecondsRealtime(0.5f);
        rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
    }

    //Cooldown
    IEnumerator cooldownPulo()
    {
        podePular = false;
        yield return new WaitForSecondsRealtime(8);
        podePular = true;  
    }

    IEnumerator cooldownCorte()
    {
        podeCortar = false;
        yield return new WaitForSecondsRealtime(2);
        podeCortar = true;
    }

    public  void corteRapido ()
    {
        vidaPlayerScript.life -= danoDoCorte;
        kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if(posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
        }
        else
        {
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
        }
    }

    private void cortePuxao ()
    {
        if (posicaoDoJogador)
        {

        }
    }
    /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            corteRapido();
        }
    }
    */
        /*Tela (transform) - Jogador 
        if (Vector2.Distance(transform.position, posicaoDoJogador.position) > 5)
        {
            Debug.Log("Tela - Jogador > 5");
        }
        if (Vector2.Distance(transform.position, posicaoDoJogador.position) < 5)
        {
            Debug.Log("Tela - Jogador < 5");
        }

        //Jogador - Tela (transform)
        if (Vector2.Distance(posicaoDoJogador.position, transform.position) > 5)
        {
            Debug.Log("Jogador-Tela > 5");
        }
        if (Vector2.Distance(posicaoDoJogador.position, transform.position) < 5)
        {
            Debug.Log("Jogador-Tela < 5");
        }

        //Boss - Jogador
        if (Vector2.Distance(posicaoDoBoss.position, posicaoDoJogador.position) < 5)
        {
            Debug.Log("Boss - Jogador if 4");
        }
        */
}
