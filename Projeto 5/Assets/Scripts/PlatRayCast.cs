using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRayCast : MonoBehaviour
{

    void Update()
    {
        RaycastDoPersonagem();
    }
    void RaycastDoPersonagem()
    {
        RaycastHit plataforma;
        if (Physics.Raycast(transform.position, transform.up, out plataforma, 3 , LayerMask.GetMask("plataforma")))
        {
            if (plataforma.collider != null && plataforma.collider.tag == "plataformatag")
            {
                GetComponent<CapsuleCollider> () .isTrigger = true;
              
            }
        }
        if (Physics.Raycast(transform.position + transform.up * -1, -transform.up, out plataforma, 3, LayerMask.GetMask("plataforma")))
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
    
}

