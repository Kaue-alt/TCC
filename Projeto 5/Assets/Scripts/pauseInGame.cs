using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseInGame : MonoBehaviour
{

    private bool paused = false;

    public GameObject telaPause, hud;

    public Fade fadeScript;

    void Start()
    {
        telaPause.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Pausando/Despausando com Esc
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                telaPause.SetActive(false);
                hud.SetActive(true);
                paused = false;
            }
        }

        //Ativando Menu de pause
        if (paused)
        {
            telaPause.SetActive(true);
            hud.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Despausando com o botão no menu
    public void OnClickButtonBackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        telaPause.SetActive(false);
        hud.SetActive(true);
        paused = false;
    }

    public void OnClickButtonBackToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        telaPause.SetActive(false);
        paused = false;
        fadeScript.Transition("Menu");
    }
}
