using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    [SerializeField]
    private float doubleJumpMultiplier = 0.5f;
    [SerializeField]
    //private float gravity = 9.81f;
    private bool canDoubleJump = false;
    //private CharacterController controller;
    private float distToGround;
    private bool isGrounded;
    public float radius;
    private float horizontal;
    //private float vertical;
    private bool playingRunAudio = false;

    public LayerMask layer;
    public Vector3 dir;

    public Rigidbody rb;
    public CapsuleCollider col;  
    private Animator animator;

    public float dashSpeed;
    public float dashTime;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        this.animator = GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        distToGround = col.bounds.extents.y;
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

        isGrounded = Physics.Raycast (transform.position, - Vector3.up, distToGround + 0.1f);
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
                canDoubleJump = true;
                rb.AddForce(Vector3.up * jumpForce);
                this.animator.SetBool("bRun", false);
                this.animator.SetBool("bIdle", false);
                this.animator.SetBool("bJump", true);

        
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                rb.AddForce(Vector3.up * jumpForce * doubleJumpMultiplier);
                canDoubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += transform.forward * Time.deltaTime*dashSpeed;
        }
    }


            // =============================== CONTROLE PELO JOYSTICK ====================================================================

    
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
