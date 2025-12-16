using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayermoovementVR : MonoBehaviour
{
    private CharacterController player;
    private PlayerInput playerInput;
    Vector2 input;
    const float speed = 2f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float fallAceleration;
    [SerializeField] float jumpHeight = 2f;
    Vector3 direction;
    Vector3 velocity;
    bool isJumping;
    bool isRunning;



    private void Start()
    {
        player = GetComponent<CharacterController>();   
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
     }

    private void FixedUpdate()
    {
        direction = new Vector3(input.x, 0, input.y);

        //Velocidad de movimiento
        if (isRunning && input.y >= 0) { velocity = direction * speed * 1.5f;
        }
        else if (isRunning && input.y< 0)
        {
            velocity = direction * speed * 1.3f;
        }
        else
        {
            velocity = direction * speed;
        }

        //Movimiento en dirección de la camara
        velocity = Camera.main.transform.TransformDirection(velocity);

        //Aplicar gravedad Y salto
        SetGravity();

        //Movimiento del character
        player.Move(velocity * Time.deltaTime);

    }

    public void Agacharse()
    {
        
    }

    public void Saltar(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && player.isGrounded) {
        isJumping = true;
        }
    }
    public void Correr(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed) {
            isRunning = true;
        }
        else { isRunning = false; }
    }
    public void SetGravity()
    {
        if (player.isGrounded && !isJumping) {
            fallAceleration = -gravity * Time.deltaTime;
            velocity.y = fallAceleration;
        }
        else if ((player.isGrounded && isJumping && isRunning) )
        {
            fallAceleration = Mathf.Sqrt(jumpHeight * (gravity * 1.2f));
            velocity.y = fallAceleration;
        }
        else if (player.isGrounded && isJumping && !isRunning)
        {
            fallAceleration = Mathf.Sqrt(jumpHeight * gravity);
            velocity.y = fallAceleration;

        }
         else
        {
            isJumping = false;
            fallAceleration -= gravity * Time.deltaTime;
            velocity.y = fallAceleration;
        }

    }

}

