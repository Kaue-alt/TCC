using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;
    public GameObject TelaGameOver;
    

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
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Restart()
    {
        //TelaGameOver.SetActive(false);
        //vidaPlayerScript.Reviver();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
