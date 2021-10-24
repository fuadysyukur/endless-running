using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20f;
    public float groundHeight = 10f;
    public bool isGrounded = false;
    public bool isHoldingJump = false;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if(!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
                Debug.Log("Grounded");
            }
        }
        transform.position = pos;
    }

    private void Update()
    {
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }
}
