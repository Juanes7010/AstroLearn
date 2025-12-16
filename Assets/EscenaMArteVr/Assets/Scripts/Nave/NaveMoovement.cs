using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]

public class NaveMoovement : MonoBehaviour
{
    private CharacterController nave;
    private Transform t;
    private PlayerInput naveInput;
    Vector2 input;
    float girar;
    float x=0;
    float y=0;
    Vector3 direction;
    Vector3 velocity;




    private void Start()
    {
        nave = GetComponent<CharacterController>();
        naveInput = GetComponent<PlayerInput>();
        t = transform;
    }

    void Update()
    {
        
        input = naveInput.actions["Rotate"].ReadValue<Vector2>();
        girar = naveInput.actions["Girar"].ReadValue<float>();
    }



    private void FixedUpdate()
    {
        if (input.x > 0) {
            x += input.x*10;        
        }
        if (input.x < 0) {
            x += input.x*10;
        }

        if (input.y > 0)
        {
            y += input.y * 6;
        }
        if (input.y < 0)
        {
            y += input.y * 6;
        }


        direction = new Vector3(x, 0, y)*Time.deltaTime;

        //Movimiento en dirección de la camara
        t.localRotation = Quaternion.Euler(direction.z,direction.y,-direction.x);

    }
}
