using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    private bool crouching = false;
    private bool lerpCrouch = false;
    private bool sprinting = false;

    private float crouchTimer = 0f;
    private float lerpSpeed = 0f;

    public float playerSpeed = 5f;
    public float gravity = -9.8f;
    public float jumpheight = 3f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;

            float p = crouchTimer / 1;
            p *= p;

            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }

    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection += transform.right * input.x;
        moveDirection += transform.forward * input.y;

        controller.Move(moveDirection * playerSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);

        //Debug.Log(playerVelocity.y);

    }
    public void Jump()
    {
            if (isGrounded)
                playerVelocity.y = Mathf.Sqrt(jumpheight * -3.0f * gravity);
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            playerSpeed = 8f;
        else
            playerSpeed = 5f;
    }
}

