using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public Rigidbody2D rb;
    public Transform collisionPivot;
    public float radius;
    public LayerMask layer;
    public float jumpForce;
    public SpriteRenderer sr;
    
    // Update is called once per frame
    void Update()
    {

        // =============================== CONTROLE PELO TECLADO E MOUSE =============================================================
                   
        // Pulo tecla Space
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.OverlapCircle(collisionPivot.position, radius, layer)) // Detecta se houve colisão com algum objeto
            {
                dir.y = 0;
                rb.AddForce(Vector2.up * jumpForce);
            }
        }

        // Movimentação horizontal no teclado teclas A e D
        dir.x = Input.GetAxisRaw("Horizontal") * speed;  // Eixo x
        dir.y = rb.velocity.y;   // Eixo y (setando para considerar a física do Rigidbody)

        // Espelha o personagem no sentido que está indo quando se movimentar
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sr.flipX = true;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sr.flipX = false;
        }

        // =============================== CONTROLE PELO JOYSTICK ====================================================================

    }

    void FixedUpdate() //Essa função roda a cada 0.02 segundos, melhorando o controle na movimentação considerando elementos da física
    {
        rb.velocity = dir;
    }
}
