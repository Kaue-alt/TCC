using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    GameOver GameOverScript;
    Animator anima;

    Combos comboScript;
    Movimentacao movScript;
    WeaponSwitching weaponIdScript;
    dashMove dashScript;
    PlayerJump jumpScript;

    public float life = 100;
    public Image lifeBar;
    public float tempoAparecer = 3f;
    //private bool podeAparecer;

    //Respawn
    public GameObject player;
    public GameObject reset;
    public int death = 0;

    public AudioSource audioSourceDeath, audioSouceRun;

    void Start()
    {
        GameOverScript = FindObjectOfType<GameOver>();
        anima = GetComponent<Animator>();
        anima.SetInteger("countDeath", 0);

        comboScript = FindObjectOfType<Combos>();
        movScript = FindObjectOfType<Movimentacao>();
        weaponIdScript = FindObjectOfType<WeaponSwitching>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();

        if (ValorCenas.vida != 0)
        {
            life = ValorCenas.vida;
        }
    }

    
    void Update()
    {
        // Movimenta a barra de vida
        life = Mathf.Clamp(life, 0, 100);
        lifeBar.fillAmount = life / 100;

    }

    void FixedUpdate()
    {
        
        if (life <= 0)
        {
            audioSouceRun.Stop();
            audioSourceDeath.Play();
            anima.SetBool("bDeath", true);
            
            Debug.Log("Game Over");
            death ++;
            //player.transform.position = reset.transform.position;          
        }

        if (death == 1)
        {
            StartCoroutine(telaGameOver());
        }

        ValorCenas.vida = life;
    }

    
    public void Reviver()
    {
        life = 100;
        Time.timeScale = 1;
    }

    IEnumerator telaGameOver()
    {
        comboScript.enabled = false;
        movScript.enabled = false;
        weaponIdScript.enabled = false;
        dashScript.enabled = false;
        jumpScript.enabled = false;
        anima.SetBool("bRun", false);
        anima.SetBool("bJump", false);
        anima.SetBool("bFall", false);
        anima.SetBool("bDash", false);
        anima.SetBool("bIdle", false);
        yield return new WaitForSecondsRealtime(0.05f);
        anima.SetInteger("countDeath", 1);
        yield return new WaitForSecondsRealtime(4f);
        GameOverScript.openTelaGameOver();
    }

}
