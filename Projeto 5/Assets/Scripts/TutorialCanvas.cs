using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    Combos combosScript;
    Movimentacao movScript;
    void Start()
    {
        combosScript = FindObjectOfType<Combos>();
        movScript = FindObjectOfType<Movimentacao>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("funfo");
            //dialogBox.SetActive(true);
            combosScript.enabled = false;
            movScript.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //dialogBox.SetActive(false);
            movScript.enabled = true;
            combosScript.enabled = true;
        }
    }
}
