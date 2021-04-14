using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{
    private Rigidbody rb;
    private int direction;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;

            }

        }else if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector2.left * dashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
        }
    }
}
