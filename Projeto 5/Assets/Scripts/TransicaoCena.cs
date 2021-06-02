using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransicaoCena : MonoBehaviour
{
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
        switch (col.gameObject.tag)
        {
            case "Fase2":
                Debug.Log("Colidiu");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("FaseEsgoto", LoadSceneMode.Single);
                }
                break;
        }
    }
}
