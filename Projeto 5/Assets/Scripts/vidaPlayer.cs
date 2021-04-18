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

    public AudioSource audioSourceDeath;

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
            audioSourceDeath.Play();
            Debug.Log("Game Over");
            Time.timeScale = 0;

            GameOverScript.openTelaGameOver();
            //player.transform.position = reset.transform.position;          
        }
    }

    
    public void Reviver()
    {
        life = 100;
        Time.timeScale = 1;
    }


}
