using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    GameOver GameOverScript;

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
            Debug.Log("Game Over");
            death ++;
            //player.transform.position = reset.transform.position;          
        }

        if (death == 1)
        {
            GameOverScript.openTelaGameOver();
        }
    }

    
    public void Reviver()
    {
        life = 100;
        Time.timeScale = 1;
    }


}
