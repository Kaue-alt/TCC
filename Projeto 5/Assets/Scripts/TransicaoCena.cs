using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransicaoCena : MonoBehaviour
{
    public GameObject textoIntereacao;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision col)
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
        }
    }
}
