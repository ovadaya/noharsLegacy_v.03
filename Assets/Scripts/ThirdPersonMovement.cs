using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 6f;
    public float sprintSpeed = 14f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpHeight = 1f;
    public float gravity = -9.8f;

    private CharacterController controller;
    private Vector3 velocity;
    public Animator animator;
    private bool isJumping = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Lógica de salto
        if (controller.isGrounded)
        {
            velocity.y = -2f; // Resetea la velocidad vertical cuando está en el suelo

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }
        }

        // Lógica de movimiento
        MovePlayer(direction);

        // Aplicar gravedad
        ApplyGravity();
    }

    void MovePlayer(Vector3 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsAtacking", false);
            animator.SetBool("IsWalking", true);    
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);

        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Jump()
    {
        animator.SetBool("IsWalking", false);
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            if (isJumping)
            {
                Jump();
                isJumping = false;
            }
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
