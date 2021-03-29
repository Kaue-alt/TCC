using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{

    RaycastHit plataformateste;
    void Update()
    {
        RaycastDoPersonagem();
    }
    void RaycastDoPersonagem()
    {
        RaycastHit plataforma;
        if (Physics.Raycast(transform.position, transform.up, out plataforma, Mathf.Infinity, LayerMask.GetMask("plataforma")))
        {
            plataformateste.transform.collider.IsTrigger = true;
            Debug.Log("funcionou");
        }
        else
        {
            Debug.Log("não funcionou");
        }
        if (Physics.Raycast(transform.position + transform.up * -1, -transform.up, out plataforma, Mathf.Infinity, LayerMask.GetMask("plataforma")))
        {
            plataformateste.transform.collider.IsTrigger = false;
        }
    }
}
}
