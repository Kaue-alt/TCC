using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;

    Movimentacao movScript;

    Combos combosScript;

    DialogoController dialogoController;
    // Start is called before the first frame update
    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          
            if (!dialogoConcluido)
            {
                dialogoController.ProximaFala(falas[0]);
            }
            else
            {
                dialogoController.ProximaFala(falas[1]);
            }
            dialogoConcluido = true;
            //dialogBox.SetActive(true);
            //combosScript.enabled = false;
            //movScript.enabled = true;
        }
    }
}
