using UnityEngine;

public class DisparoPayaso : MonoBehaviour
{
    public Camera camara;
    public LayerMask capaPayaso;
    public ControladorPayasos controlador;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = camara.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit, 100f, capaPayaso))
            {
                if (hit.collider.CompareTag("Payaso"))
                {
                    Destroy(hit.collider.gameObject);
                    controlador.RegistrarImpacto();
                }
            }
        }
    }
}