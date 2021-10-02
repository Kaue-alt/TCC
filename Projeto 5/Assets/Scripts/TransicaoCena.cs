using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransicaoCena : MonoBehaviour
{
    public GameObject textoIntereacao;

    public Fade fadeScript;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GetComponent<Animator>().SetBool("bTutorial", true);

            if(GetComponent<Animator>().GetInteger("countStand") == 0)
            {
                StartCoroutine(waitStand());
            }

        }
        else
        {
            GetComponent<Animator>().SetBool("bTutorial", false);
        }

        fadeScript = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        //textoIntereacao.SetActive(true);
        switch (col.gameObject.tag)
        {
            /*case "Fase2":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fadeScript.Transition("FaseEsgoto");
                }
                break;*/
            case "Fase3":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fadeScript.Transition("FaseEsgoto 1-A");
                }
                break;
            case "Fase4":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fadeScript.Transition("FaseEsgoto 2-A");
                }
                break;
            case "Fase5":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fadeScript.Transition("FaseEsgoto 3-A");
                }
                break;
            case "Fase6":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    fadeScript.Transition("FaseCidadeQuebrada");
                }
                break;
        }
    }

    IEnumerator waitStand()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Animator>().SetInteger("countStand", 1);
    }
}
