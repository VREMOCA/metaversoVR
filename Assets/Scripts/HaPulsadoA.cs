using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HaPulsadoA : MonoBehaviour
{
    public LayerMask layer;
    //private UnityEngine.InputSystem.XR.XRController gamepad;
    public NavMeshAgent navAgent;


    public void HaPulsadoElBoton()
    {
        Debug.Log("ooooooooooo");
        /*
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.green, 2);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2000, layer))
        {
            Debug.Log("raycast creado");
            navAgent.Warp(hit.point);
            //if (hit.collider.CompareTag("Floor"))
            //{
            //    Debug.Log("raycast impacta");
            //    Vector3 targetPosition = hit.point;
            //    navAgent.Warp(targetPosition);
            //}
        }
        */
    }
}
