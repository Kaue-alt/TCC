using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseInGame : MonoBehaviour
{

    private bool paused = false;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        //Pausando com Esc
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                GetComponent<Canvas>().enabled = false;
                paused = false;
            }
        }

        //Ativando Menu de pause
        if (paused)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }

    //Despausando com o botão no menu
    public void OnClickButtonBackToGame()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        paused = false;
    }
}
