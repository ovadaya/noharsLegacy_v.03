using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class movimiento_Jugador : MonoBehaviour
{
   // Start is called before the first frame update
   public enum State { walk, sprint, maxState }


   public State statepc = State.walk;
   public float sprint;
   public float speed;
   public float rotationspeed;
   public float jumpspeed;

   public CharacterController characterController;
   private float ySpeed;
   private float originalStepOffset;

   [SerializeField]
   private Transform cameraTransform;
   void Start()
   {


      originalStepOffset = characterController.stepOffset;
   }

   // Update is called once per frame
   void Update()
   {
      transform.position = characterController.transform.position;
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
      float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
      movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
      movementDirection.Normalize();

      ySpeed += Physics.gravity.y * Time.deltaTime;

      if (characterController.isGrounded)
      {
         characterController.stepOffset = originalStepOffset;
         ySpeed = -0.5f;
         if (Input.GetButtonDown("Jump"))
         {
            ySpeed = jumpspeed;

         }
      }
      else
      {
         characterController.stepOffset = 0;

      }

      Vector3 velocity = movementDirection * magnitude;
      velocity.y = ySpeed;

      statepc = Cambio();

      if (statepc == State.walk)
         characterController.Move(velocity * Time.deltaTime);

      if (statepc == State.sprint)
         characterController.Move(velocity * sprint * Time.deltaTime);

      if (movementDirection != Vector3.zero)
      {

         Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

         transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);

      }


   }

   public State Cambio()
   {
      if (Input.GetKey(KeyCode.LeftShift))
      {
         return State.sprint;
      }
      else
      {
         return State.walk;
      }
   }

   private void OnApplicationFocus(bool focus)
   {
      if (focus)
      {
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
      }
      else
      {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
      }
   }
}
