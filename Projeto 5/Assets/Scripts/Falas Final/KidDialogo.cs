using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;

    Movimentacao movScript;

    Combos combosScript;

    KidController dialogoController;

    void Start()
    {
        dialogoController = FindObjectOfType<KidController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();

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
        }
    }
}
