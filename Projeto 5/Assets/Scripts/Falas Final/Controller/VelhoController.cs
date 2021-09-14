using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelhoController : MonoBehaviour
{
    public GameObject painelDeDialogoVelho;

    public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;

    Movimentacao movScript;

    Combos combosScript;

    FalaVelho falona;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoNPC, IconeVelho, IconePlayer;

    void Start()
    {
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();
    }

    void Update()
    {
        if (!painelDeDialogoVelho.activeInHierarchy)
        {
            IconeVelho.SetActive(false);
            IconePlayer.SetActive(false);
        }
        if (textoNPC.activeInHierarchy)
        {
            IconeVelho.SetActive(true);
            IconePlayer.SetActive(false);
        }
        else if (!textoNPC.activeInHierarchy && painelDeDialogoVelho.activeInHierarchy)
        {
            IconeVelho.SetActive(false);
            IconePlayer.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if (falona.respostinha.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtiva = false;
                painelDeDialogoVelho.SetActive(false);
                falaNPC.gameObject.SetActive(false);
                movScript.enabled = true;
                combosScript.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void MostrarRespostas()
    {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for (int i = 0; i < falona.respostinha.Length; i++)
        {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogoVelho.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falona.respostinha[i].resposta;
            tempResposta.GetComponent<AnwserButton>().Setup(falona.respostinha[i]);
        }
    }
    public void ProximaFalaVelho(FalaVelho falinha)
    {
        Cursor.lockState = CursorLockMode.None;
        movScript.enabled = false;
        combosScript.enabled = false;
        runSound.Stop();
        animator.SetBool("bIdle", true);
        animator.SetBool("bRun", false);
        falona = falinha;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogoVelho.SetActive(true);
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falona.falinha;
    }

    void LimparRespostas()
    {
        AnwserButton[] buttons = FindObjectsOfType<AnwserButton>();
        foreach (AnwserButton button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
