using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelhoDialogo : MonoBehaviour
{
    public FalaVelho[] falona = new FalaVelho[2];

    private bool dialogoConcluido = false;

    Movimentacao movScript;

    Combos combosScript;

    VelhoController dialogoController;

    void Start()
    {
        dialogoController = FindObjectOfType<VelhoController>();
        movScript = FindObjectOfType<Movimentacao>();
        combosScript = FindObjectOfType<Combos>();

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!dialogoConcluido)
            {
                dialogoController.ProximaFalaVelho(falona[0]);
            }
            else
            {
                dialogoController.ProximaFalaVelho(falona[1]);
            }
            dialogoConcluido = true;
        }
    }
}
