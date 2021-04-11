using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    public GameObject soundAt1, soundAt3;

    public static int clicks;
    bool canClick;


    void Start()
    {
        animator = GetComponent<Animator>();
        clicks = 0;
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
