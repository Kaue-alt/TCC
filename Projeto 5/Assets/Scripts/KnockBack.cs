using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] public float knockbackStrength;

    private Animator anim;
    public bool active = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        //rb != null && 

        if (active)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }

        /*if (rb == null)
        {
            active = false;
        }*/
    }
}
