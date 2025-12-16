using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityAndCollisions : MonoBehaviour
{
    private CharacterController player;
    private Vector3 movimientoEnDirección = Vector3.zero;
    private Vector2 entrada;

    private CollisionFlags collisionFlags;
    [SerializeField] float fuerzaAlTocarSuelo;
    [SerializeField] float MultiplicarGravedad;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movimientoDeseado = transform.forward * entrada.y + transform.right * entrada.x;
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position,player.radius, Vector3.down, out hitInfo, player.height/2f,Physics.AllLayers, QueryTriggerInteraction.Ignore);
        movimientoDeseado = Vector3.ProjectOnPlane(movimientoDeseado, hitInfo.normal).normalized;
        if (player.isGrounded)
        {
            movimientoEnDirección.y = -fuerzaAlTocarSuelo;
        }
        else
        {
            movimientoEnDirección += Physics.gravity * MultiplicarGravedad * Time.fixedDeltaTime;
        }
        collisionFlags = player.Move(movimientoEnDirección * Time.fixedDeltaTime);
    }
}
