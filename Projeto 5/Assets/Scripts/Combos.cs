using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    public GameObject soundAt1, soundAt3;

    public CapsuleCollider colliderArma;

    public CapsuleCollider colliderArma2;

    public int clicks;
    public bool canClick;
    private bool firstAttack, secondAttack, thirdAttack;

    Movimentacao movScript;
    WeaponSwitching weaponIdScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        clicks = 0;
        canClick = true;

        movScript = FindObjectOfType<Movimentacao>();
        weaponIdScript = FindObjectOfType<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetInteger("IdArma", weaponIdScript.selectedWeapon);
        AttackState();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("standUp"))
        {
            movScript.enabled = false;
        }
        else
        {
            movScript.enabled = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("standUp") || Cursor.lockState != CursorLockMode.Locked)
        {
            canClick = false;
        }
        else
        {
            canClick = true;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        {
            movScript.enabled = false;
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            movScript.enabled = true;
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

        if(firstAttack && clicks == 1)
        {
            animator.SetInteger("Attack", 0);
            canClick = true;
            clicks = 0;
        }
        else if (firstAttack && clicks >= 2)
        {
            animator.SetInteger("Attack", 2);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().Play();
        }
        else if (secondAttack && clicks == 2)
        {
            animator.SetInteger("Attack", 0);
            canClick = true;
            clicks = 0;
        }
        else if (secondAttack && clicks >= 3)
        {
            animator.SetInteger("Attack", 3);
            canClick = true;

            soundAt1.GetComponent<AudioSource>().PlayDelayed(0.5f);
        }
        else if (thirdAttack)
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
        colliderArma2.enabled = true;
    }

    public void desativarCol()
    {
        colliderArma.enabled = false;
        colliderArma2.enabled = false;
    }

    public void AttackState()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_1") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_1"))
        {
            firstAttack = true;
        }
        else
        {
            firstAttack = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_2") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_2"))
        {
            secondAttack = true;
        }
        else
        {
            secondAttack = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAxe_3") || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackPipe_3"))
        {
            thirdAttack = true;
        }
        else
        {
            thirdAttack = false;
        }
    }
}
