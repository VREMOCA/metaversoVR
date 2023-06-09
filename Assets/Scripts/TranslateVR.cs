using UnityEngine;
using UnityEngine.AI;


public class TranslateVR : MonoBehaviour
{
    public LayerMask layer;
    public GameObject prefabMarcadorMovimiento;
    //private UnityEngine.InputSystem.XR.XRController gamepad;
    public NavMeshAgent navAgent;

    private GameObject vacioParaSaberSiHePulsado;
    private GameObject marcadorMovimiento;
    [HideInInspector] public bool botonAPulsado, botonBPulsado;

    private bool enZonaIzquierda;
    private bool enZonaDerecha;
    private bool enInteractable;


    private void Awake()
    {
        marcadorMovimiento = Instantiate(prefabMarcadorMovimiento, transform.position, transform.rotation);
        marcadorMovimiento.SetActive(false);
        botonAPulsado = false;
        botonBPulsado = false;
        enZonaIzquierda = false;
        enZonaDerecha = false;
        enInteractable = false;
    }

    private void Update()
    {
        GetInput();

        if (enInteractable)
        {
            //GirarJugador();
        }
        else
        {
            TeleportPlayer();
        }

    }

    private void GetInput()
    {
        CheckMarcador();

        botonAPulsado = CheckPulsadoA();
        botonBPulsado = CheckPulsadoB();

        if (CheckPulsadoB())
        {
            Debug.Log("he pulsado B");
        }
    }

    private Vector3 GetCollisionRay()
    {
        Vector3 sitioCollision = Vector3.zero;

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.green, 2);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2000, layer))
        {
            sitioCollision = hit.point;
        }

        return sitioCollision;
    }

    private void MarcarTeleport(Vector3 posColision)
    {
        marcadorMovimiento.transform.position = transform.position;
        marcadorMovimiento.SetActive(true);
        marcadorMovimiento.transform.LookAt(posColision);
    }



    private void TeleportPlayer()
    {
        marcadorMovimiento.SetActive(false);
        Vector3 sitioColision = GetCollisionRay();
        if (sitioColision != Vector3.zero)
        {
            MarcarTeleport(sitioColision);
            if (botonAPulsado)
            {
                navAgent.Warp(sitioColision);
            }
        }
    }


    private bool CheckPulsadoA()
    {
        if (vacioParaSaberSiHePulsado.transform.position.y == 1)
        {
            Vector3 posSecret = vacioParaSaberSiHePulsado.transform.position;
            posSecret.y = 0;
            vacioParaSaberSiHePulsado.transform.position = posSecret;
            return true;
        }

        return false;
    }

    private bool CheckPulsadoB()
    {
        if (vacioParaSaberSiHePulsado.transform.position.x == 1)
        {
            Vector3 posSecret = vacioParaSaberSiHePulsado.transform.position;
            posSecret.x = 0;
            vacioParaSaberSiHePulsado.transform.position = posSecret;
            return true;
        }

        return false;
    }

    private bool CheckMarcador()
    {
        if (vacioParaSaberSiHePulsado == null)
        {
            GameObject[] detectores = GameObject.FindGameObjectsWithTag("TagParaDetectarBotonA");
            if (detectores.Length > 0)
            {
                vacioParaSaberSiHePulsado = detectores[0];
                return true;
            }
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RotaIzquierda"))
        {
            enInteractable = true;
            enZonaIzquierda = true;
        }

        if (other.gameObject.CompareTag("RotaDerecha"))
        {
            enInteractable = true;
            enZonaDerecha = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RotaIzquierda"))
        {
            enInteractable = false;
            enZonaIzquierda = false;
        }

        if (other.gameObject.CompareTag("RotaDerecha"))
        {
            enInteractable = false;
            enZonaDerecha = false;
        }
    }

    private void GirarJugador()
    {
        if (enZonaIzquierda && botonAPulsado)
        {
            navAgent.transform.Rotate( Vector3.up, 20f );
            return;
        }

        if (enZonaDerecha && botonAPulsado)
        {
            navAgent.transform.Rotate( Vector3.up, -20f );
            return;
        }
    }

}




