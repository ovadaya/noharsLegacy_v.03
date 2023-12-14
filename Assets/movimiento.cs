using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float sprint;
   public float speed;
   public float rotationspeed;
   public float jumpspeed;

   private CharacterController characterController;
   private float ySpeed;
   private float originalStepOffset;
    void Start()
    {
       characterController = GetComponent<CharacterController>();
       originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");

       Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
       float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
       movementDirection.Normalize();

       ySpeed += Physics.gravity.y * Time.deltaTime;

       if(characterController.isGrounded){
        characterController.stepOffset = originalStepOffset;
        ySpeed = -0.5f;
        if(Input.GetButtonDown("Jump")){
                ySpeed = jumpspeed;

        }
       }
       else{
            characterController.stepOffset = 0;

       }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

       if(movementDirection != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);

       }

      
   }
}
