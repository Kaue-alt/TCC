using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComandanteController : MonoBehaviour
{
    public GameObject painelDeDialogoComandante;

    public Text falaComandante;

    public GameObject respostaComandante;

    private bool falaAtivaComandante = false;

    Movimentacao movScript;
    Combos combosScript;
    dashMove dashScript;
    PlayerJump jumpScript;
    pauseInGame pauseScript;

    FalaComandante falasComandante;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoComandante, IconePlayer, IconeComandante;

    public GameObject hudVida, hudDash, hudArmas;

    void Start()
    {
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        pauseScript = FindObjectOfType<pauseInGame>();
    }

    void Update()
    {
        if (!painelDeDialogoComandante.activeInHierarchy)
        {
            IconeComandante.SetActive(false);
            IconePlayer.SetActive(false);
            hudVida.SetActive(true);
            hudArmas.SetActive(true);
            hudDash.SetActive(true);
        }
        if (textoComandante.activeInHierarchy)
        {
            IconeComandante.SetActive(true);
            IconePlayer.SetActive(false);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }
        else if (!textoComandante.activeInHierarchy && painelDeDialogoComandante.activeInHierarchy)
        {
            IconeComandante.SetActive(false);
            IconePlayer.SetActive(true);
            hudVida.SetActive(false);
            hudArmas.SetActive(false);
            hudDash.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && falaAtivaComandante)
        {
            if (falasComandante.respostasComandante.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtivaComandante = false;
                painelDeDialogoComandante.SetActive(false);
                falaComandante.gameObject.SetActive(false);
                movScript.enabled = true;
                combosScript.enabled = true;
                jumpScript.enabled = true;
                dashScript.enabled = true;
                pauseScript.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void MostrarRespostas()
    {
        falaComandante.gameObject.SetActive(false);
        falaAtivaComandante = false;

        for (int i = 0; i < falasComandante.respostasComandante.Length; i++)
        {
            GameObject tempResposta = Instantiate(respostaComandante, painelDeDialogoComandante.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falasComandante.respostasComandante[i].respostaComandante;
            tempResposta.GetComponent<AnswerButtonComandante>().Setup(falasComandante.respostasComandante[i]);
        }
    }
    public void ProximaFalaComandante(FalaComandante falinhaComandante)
    {
        Cursor.lockState = CursorLockMode.None;
        movScript.enabled = false;
        combosScript.enabled = false;
        jumpScript.enabled = false;
        dashScript.enabled = false;
        pauseScript.enabled = false;
        runSound.Stop();
        animator.SetBool("bIdle", true);
        animator.SetBool("bRun", false);
        falasComandante = falinhaComandante;

        LimparRespostas();

        falaAtivaComandante = true;
        painelDeDialogoComandante.SetActive(true);
        falaComandante.gameObject.SetActive(true);

        falaComandante.text = falasComandante.falaComandante;
    }

    void LimparRespostas()
    {
        AnswerButtonComandante[] buttons = FindObjectsOfType<AnswerButtonComandante>();
        foreach (AnswerButtonComandante button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
