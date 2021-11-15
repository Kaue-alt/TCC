using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Boss : MonoBehaviour
{

    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;
    vidaBoss vidaDoBoss;
    Movimentacao scriptMovimentacao;
    dashMove scriptDash;

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
    public float sugada;
    public Rigidbody rigidBodyBoss;
    public Rigidbody rigidBodyPlayer;

    //Permissões
    private bool podePular = true;
    private bool podeCortar = true;
    public bool estaSugando = false;

    //Dano
    public float danoDoCorteLeve;
    public float danoDoCortePesado;
    public float danoDoCorteDuplo;
    public float danoDaInvestida;
    private int chanceDeAtaque;

    //Animacoes
    public GameObject modelBoss;
    private Animator animaBoss;
    private int contAnimLife = 0;

    void Start()
    {
        //Pegar posição do Player e Boss
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posicaoDoBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();

        animaBoss = modelBoss.GetComponent<Animator>();

        //Invocar Scripts
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();
        vidaDoBoss = FindObjectOfType<vidaBoss>();
        scriptMovimentacao = FindObjectOfType<Movimentacao>();
        scriptDash = FindObjectOfType<dashMove>();
    }

    void Update()
    {
        if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (estaSugando == true)
        {
            animaBoss.SetBool("bPull", true);
            if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //&& (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 1))
            {
                rigidBodyPlayer.AddForce(Vector3.right * sugada, ForceMode.Acceleration);
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaEsquerda");
                scriptDash.enabled = false;
            }
            else //(posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) // && (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 1))
            {
                rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration );
                scriptMovimentacao.speed = 1;
                Debug.Log("sugandoCorrotinaDireita");
                scriptDash.enabled = false;
            }
        }
        else
        {
            scriptDash.enabled = true;
            scriptMovimentacao.speed = 5;
        }

        //ATAQUES

            //Pular para a direita
        if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 7 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //FUNCIONA
        {
                StartCoroutine(puloDireita());
                Debug.Log("Pulou p/ Direita");
        }

            //Pular para a esquerda
        if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 7 && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //FUNCIONA
        {
                StartCoroutine(puloEsquerda());
                Debug.Log("Pulou p/ Esquerda");
        }

            //Cortar
        if (vidaDoBoss.life >= 50 && podeCortar == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
        {
                StartCoroutine(cooldownCorte());
                corteRapido();
                Debug.Log("cortou Leve!");
        }
        if (vidaDoBoss.life < 50 && podeCortar == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
        {
                StartCoroutine(cooldownCorte());
                cortePesado();
                Debug.Log("cortou Pesado!");
        }

        if(contAnimLife == 0 && vidaDoBoss.life <= 50)
        {
            animaBoss.SetInteger("HalfLife", 1);
            contAnimLife++;
            StartCoroutine(animaHalfLife());
        }

        /*if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 6 && posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //FUNCIONA
        {
                Debug.Log("Pula p/ Esquerda");
                StartCoroutine(puloEsquerda());
                StartCoroutine(cooldownPulo());
        }
        if (podePular == true && Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 6 && posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
                Debug.Log("Pula p/ Direita");
                StartCoroutine(puloDireita());
                StartCoroutine(cooldownPulo());
        }
        */
    }

    //Controlar direção dos pulos
    IEnumerator puloDireita()
    {
        podePular = false;
        if (podePular == false)
        {
            animaBoss.SetBool("bJump", true);

            //yield return new WaitForSecondsRealtime(1);
            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.right * jumpSpeedRight, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.65f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            //yield return new WaitForSecondsRealtime(2);
            //rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            yield return new WaitForSecondsRealtime(0.5f);

            animaBoss.SetBool("bJump", false);

            if (vidaDoBoss.life <= 50)
            {
                estaSugando = true;

            }
            /*if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
                {
                estaSugando = false;
                }
                */
            yield return new WaitForSecondsRealtime(8);
            podePular = true;
        }
    }

    IEnumerator puloEsquerda()
    {
        podePular = false;
        if (podePular == false)
        {
            animaBoss.SetBool("bJump", true);

            //yield return new WaitForSecondsRealtime(1);
            rigidBodyBoss.AddForce(Vector3.up * jumpSpeedUp, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.3f);
            rigidBodyBoss.AddForce(Vector3.left * jumpSpeedLeft, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.65f);
            rigidBodyBoss.AddForce(Vector3.down * jumpSpeedDown, ForceMode.VelocityChange);
            yield return new WaitForSecondsRealtime(0.5f);

            animaBoss.SetBool("bJump", false);

            if (vidaDoBoss.life <= 50)
            {
                estaSugando = true;
            }
            //estaSugando = true;
            /*if (Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) < 3)
            {
                estaSugando = false;
            }
            */
            yield return new WaitForSecondsRealtime(8);
            podePular = true;
        }
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
        animaBoss.SetBool("bPull", false);
        yield return new WaitForSecondsRealtime(0.5f);
        animaBoss.SetInteger("Attack", 0);
        yield return new WaitForSecondsRealtime(1.5f);
        podeCortar = true;
    }

    void sorteiaAtaque()
    {
        chanceDeAtaque = Random.Range(1, 11);
        Debug.Log("Num: " + chanceDeAtaque);
    }

    private void corteRapido()
    {
        vidaPlayerScript.life -= danoDoCorteLeve;
        kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {          
            animaBoss.SetInteger("Attack", 1);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
        }
        else
        {
            animaBoss.SetInteger("Attack", 1);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
        }
        
    }

    private void corteDuplo()
    {
        vidaPlayerScript.life -= danoDoCorteDuplo;
        kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            animaBoss.SetInteger("Attack", 3);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
        }
        else
        {
            animaBoss.SetInteger("Attack", 3);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
        }

    }

    private void cortePesado()
    {
        vidaPlayerScript.life -= danoDoCortePesado;
        kbScript.active = true;
        fbPlayerScript.damage = true;

        //Dash p/ ataque em direção ao player
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x)
        {
            animaBoss.SetInteger("Attack", 2);
            rigidBodyBoss.AddForce(Vector3.right * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
        else
        {
            animaBoss.SetInteger("Attack", 2);
            rigidBodyBoss.AddForce(Vector3.left * speedDashCorte, ForceMode.VelocityChange);
            estaSugando = false;
        }
    }

    private void sugadaDirecao()
    {
        animaBoss.SetBool("bPull", true);
        if (posicaoDoJogador.transform.position.x < posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            scriptMovimentacao.speed = 1;
            Debug.Log("sugandoCorrotinaEsquerda");
        }
        if (posicaoDoJogador.transform.position.x > posicaoDoBoss.transform.position.x) //&& Vector2.Distance(posicaoDoJogador.position, posicaoDoBoss.position) > 2)
        {
            rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
            scriptMovimentacao.speed = 1;
            Debug.Log("sugandoCorrotinaDireita");
        }
        animaBoss.SetBool("bPull", false);
    }

    IEnumerator animaHalfLife()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        animaBoss.SetInteger("ContLife", contAnimLife);
    }


    /* private void sugadaEsquerda()
     {
         Debug.Log("Sugada esquerda");
         rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
     }

     private void sugadaDireita()
     {
         Debug.Log("Sugada direita");
         rigidBodyPlayer.AddForce(Vector3.left * sugada, ForceMode.Acceleration);
     }
     */
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
