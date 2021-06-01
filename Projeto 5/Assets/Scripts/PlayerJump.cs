using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 5;
    public Rigidbody rigidBody;
    private bool onGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || MAX_JUMP > currentJump))
        {
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
    }
}
