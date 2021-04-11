using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float radius;
    private float horizontal;
    //private float vertical;
    private bool playingRunAudio = false;

    public LayerMask layer;
    public Vector3 dir;

    public Rigidbody rb;
    //public Transform collisionPivot;    
    public MeshRenderer mr;
    public CapsuleCollider col;  
    private Animator animator;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        this.animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        this.Animations();
        // =============================== CONTROLE PELO TECLADO E MOUSE =============================================================

        // Movimentação horizontal no teclado teclas A e D
        dir.x = Input.GetAxisRaw("Horizontal") * speed;  // Eixo x
        dir.y = rb.velocity.y;   // Eixo y (setando para considerar a física do Rigidbody)
        dir.z = 0;

        //vertical = 0;
        horizontal = dir.x;

        if (!Input.anyKeyDown)
        {
            this.animator.SetBool("bRun", false);
            this.animator.SetBool("bIdle", true);
            this.animator.SetBool("bJump", false);
        }

        // Espelha o personagem no sentido que está indo quando se movimentar
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            this.animator.SetBool("bRun", true);
            this.animator.SetBool("bIdle", false);
            this.animator.SetBool("bJump", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            this.animator.SetBool("bRun", true);
            this.animator.SetBool("bIdle", false);
            this.animator.SetBool("bJump", false);
        }

        //Colocando som de corrida atrelado à animação

        /*if(this.animator.GetBool("bRun") && !playingRunAudio)
        {
            GetComponent<AudioSource>().Play();
            playingRunAudio = true;
        }

        if (this.animator.GetBool("bJump") && playingRunAudio)
        {
            GetComponent<AudioSource>().Stop();
            playingRunAudio = false;
        }

        if (!this.animator.GetBool("bRun") && playingRunAudio)
        {
            GetComponent<AudioSource>().Stop();
            playingRunAudio = false;
        }*/

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !playingRunAudio)
        {
            GetComponent<AudioSource>().Play();
            playingRunAudio = true;
        }

        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && playingRunAudio)
        {
            GetComponent<AudioSource>().Stop();
            playingRunAudio = false;
        }


        // Pulo tecla Space
        if (Input.GetButtonDown("Jump"))
        {
            //if (Physics2D.OverlapCircle(collisionPivot.position, radius, layer)) // Detecta se houve colisão com algum objeto
            //{
            //dir.y = 0;
            rb.AddForce(Vector3.up * jumpForce);
            this.animator.SetBool("bRun", false);
            this.animator.SetBool("bIdle", false);
            this.animator.SetBool("bJump", true);
            //}
        }

        // =============================== CONTROLE PELO JOYSTICK ====================================================================

    }
    private void Animations()
    {
        //this.animator.SetFloat("Horizontal", horizontal);
        //this.animator.SetFloat("Vertical", vertical);
    }



    void FixedUpdate() //Essa função roda a cada 0.02 segundos, melhorando o controle na movimentação considerando elementos da física
    {
        rb.velocity = dir;
    }
}
