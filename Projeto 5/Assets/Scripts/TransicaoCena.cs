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
            case "Fase2":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseEsgoto", LoadSceneMode.Single);
                }
                break;
            case "Fase3":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseEsgoto 1-A", LoadSceneMode.Single);
                }
                break;
            case "Fase4":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseEsgoto 2-A", LoadSceneMode.Single);
                }
                break;
            case "Fase5":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseEsgoto 3-A", LoadSceneMode.Single);
                }
                break;
            case "Fase6":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseCidadeQuebrada", LoadSceneMode.Single);
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
