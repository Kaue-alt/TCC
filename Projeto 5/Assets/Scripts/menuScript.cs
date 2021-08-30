using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Fade fadeScript;
    vidaPlayer vidaPlayerScript;
   
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        //vidaPlayerScript.death = 0;
    }
    //Clique no botao para alterar cena para jogo
    public void OnClickButtonPlay()
    {
        fadeScript.Transition("Tutorial");
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Clique no botao para alterar cena para tela de opcoes
    public void OnClickButtonOptions()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
