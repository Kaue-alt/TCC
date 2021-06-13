using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    public GameObject soundAt1, soundAt3;

    public CapsuleCollider colliderArma;

    public static int clicks;
    public bool canClick;

    Movimentacao movScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        clicks = 0;
        canClick = true;

        movScript = FindObjectOfType<Movimentacao>();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("standUp"))
        {
            movScript.enabled = false;
        }
        else
        {
            movScript.enabled = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run") || animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("standUp"))
        {
            canClick = false;
        }
        else
        {
            canClick = true;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Combo();
        }
    }

    void Combo()
    {
        if (canClick)
        {
            clicks++;
        }
        if (clicks == 1)
        {
            animator.SetInteger("Attack", 1);

            soundAt1.GetComponent<AudioSource>().PlayDelayed(0.15f);
        }
    }

    void ComboManager()
    {
        canClick = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && clicks == 1)
        {
            animator.SetInteger("Attack", 0);
            canClick = true;
            clicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && clicks >= 2)
        {
            animator.SetInteger("Attack", 2);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().Play();
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks == 2)
        {
            animator.SetInteger("Attack", 0);
            canClick = true;
            clicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks >= 3)
        {
            animator.SetInteger("Attack", 3);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().PlayDelayed(0.5f);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
        {
            animator.SetInteger("Attack", 0);
            canClick = true;
            clicks = 0;
        }
        else
        {
            canClick = true;
            clicks = 0;
        }
    }

    public void ativarCol()
    {
        colliderArma.enabled = true;
    }

    public void desativarCol()
    {
        colliderArma.enabled = false;
    }
}
