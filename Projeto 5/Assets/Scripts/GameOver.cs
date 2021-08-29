using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    public GameObject TelaGameOver;
    public Fade fadeScript;


    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
    }


    void Update()
    {

    }

    public void openTelaGameOver()
    {
        Time.timeScale = 0;
        TelaGameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void goMainMenu()
    {
        Time.timeScale = 1;
        fadeScript.Transition("Menu");
        TelaGameOver.SetActive(false);
    }

    public void Restart()
    {
        vidaPlayerScript.Reviver();
        fadeScript.Transition("Tutorial");
        TelaGameOver.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        vidaPlayerScript.death = 0;
    }
}
