using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public GameObject painelDeDialogo;

    public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;

    Movimentacao movScript;

    Combos combosScript;

    FalaNPC falas;

    public Animator animator;

    public AudioSource runSound;

    public GameObject textoNPC, IconeCrianca, IconePlayer;

    // Start is called before the first frame update
    void Start()
    {
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!painelDeDialogo.activeInHierarchy)
        {
            IconeCrianca.SetActive(false);
            IconePlayer.SetActive(false);
        }
        if(textoNPC.activeInHierarchy)
        {
            IconeCrianca.SetActive(true);
            IconePlayer.SetActive(false);          
        }
        else if (!textoNPC.activeInHierarchy && painelDeDialogo.activeInHierarchy)
        {
            IconeCrianca.SetActive(false);
            IconePlayer.SetActive(true);
        }

        if(Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if(falas.respostas.Length > 0)
            {
                MostrarRespostas();
            }
            else
            {
                falaAtiva = false;
                painelDeDialogo.SetActive(false);
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

        for (int i = 0; i < falas.respostas.Length; i++ )
        {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<AnwserButton>().Setup(falas.respostas[i]);
        }
    }
    public void ProximaFala(FalaNPC fala)
    {
        Cursor.lockState = CursorLockMode.None;
        movScript.enabled = false;
        combosScript.enabled = false;
        runSound.Stop();
        animator.SetBool("bIdle", true);
        animator.SetBool("bRun", false);
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true); 

        falaNPC.text = falas.fala;
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
