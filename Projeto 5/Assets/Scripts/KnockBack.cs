using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] public float knockbackStrength;

    private Animator anim;
    private bool attacking = false;
    public bool active = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        /*
        if(anim.GetInteger("Attack") == 0)
        {
            attacking = false;
        }
        else
        {
            attacking = true;
        }
        */
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if(rb != null && active)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);

            active = false;
        }
    }
}
