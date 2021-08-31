using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{
    public ParticleSystem dashEffect;
    private Rigidbody rb;
    private int direction;
    public float dashSpeed;
    public float cooldown;
    public bool canDash = true;
    private Animator animator;

    Combos combosScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        this.animator = GetComponent<Animator>();
        combosScript = FindObjectOfType<Combos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && canDash) // REALIZANDO DASH
        {
            this.animator.SetBool("bDash", true);
            transform.position += Vector3.right * dashSpeed;
            dashEffect.Play();

            StartCoroutine(esperarCD(cooldown));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && canDash) // REALIZANDO DASH INVERTIDO
        {
            this.animator.SetBool("bDash", true);
            transform.position += Vector3.left * dashSpeed;
            dashEffect.Play();
            StartCoroutine(esperarCD(cooldown));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) // REALIZANDO DASH
        {
            this.animator.SetBool("bDash", true);
            transform.position += transform.forward * dashSpeed;
            dashEffect.Play();

            StartCoroutine(esperarCD(cooldown));
        }
    }

    IEnumerator esperarCD(float tempo)
    {
        animator.SetInteger("Attack", 0);
        combosScript.canClick = true;
        combosScript.clicks = 0;
        combosScript.colliderArma.enabled = false;
        combosScript.colliderArma2.enabled = false;

        canDash = false;

        yield return new WaitForSeconds(tempo);
        canDash = true;
    }

    void CreatEffect()
    {
        dashEffect.Play();
    }
}
