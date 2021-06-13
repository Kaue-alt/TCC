using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Fade fadeScript;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    //Clique no botão para alterar cena para jogo
    public void OnClickButtonPlay()
    {
        fadeScript.Transition("Tutorial");
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Clique no botão para alterar cena para tela de opções
    public void OnClickButtonOptions()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
