using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnJuninho : MonoBehaviour
{
    public GameObject SpawnKid;
    public GameObject kidGame;
    //public Fade fadeScript;
    //KidDialogo kidDialogo;

    TransicaoParaODia transicaoParaODia;

    void Start()
    {
        transicaoParaODia = FindObjectOfType<TransicaoParaODia>();
        /*if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GetComponent<Animator>().SetBool("bTutorial", true);

            if (GetComponent<Animator>().GetInteger("countStand") == 0)
            {
                StartCoroutine(waitStand());
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("bTutorial", false);
        }
        fadeScript = FindObjectOfType<Fade>();*/
    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            SpawnKid.gameObject.SetActive(true);
            kidGame.gameObject.SetActive(false);
            //fadeScript.Transition("FaseEsgoto");
            transicaoParaODia.ganchoTransicao += 1;
            Debug.Log("Cont = " + transicaoParaODia.ganchoTransicao);
        }
    }

    /*IEnumerator waitStand()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Animator>().SetInteger("countStand", 1);
    }*/
}
