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
        Cursor.lockState = CursorLockMode.None;
        TelaGameOver.SetActive(true);
    }

    public void goMainMenu()
    {
        TelaGameOver.SetActive(false);
        fadeScript.Transition("Menu");

    }

    public void Restart()
    {
        TelaGameOver.SetActive(false);
        vidaPlayerScript.Reviver();
        fadeScript.Transition("Tutorial");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
