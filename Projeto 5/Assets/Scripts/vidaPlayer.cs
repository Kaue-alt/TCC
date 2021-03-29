using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    GameOver GameOverScript;

    public float life = 100;
    public Image lifeBar; 
    
    
    void Start()
    {
        GameOverScript = FindObjectOfType<GameOver>();
        
    }

    
    void Update()
    {
        // Movimenta a barra de vida
        life = Mathf.Clamp(life, 0, 100);
        lifeBar.fillAmount = life / 100;

        if (life <= 0)
        {
            Debug.Log("Game Over");
            GameOverScript.openTelaGameOver();
            Time.timeScale = 0;
        }
    }

    
    public void Reviver()
    {
        life = 100;
        Time.timeScale = 1;
    }
}
