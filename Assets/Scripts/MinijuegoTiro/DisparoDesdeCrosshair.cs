using UnityEngine;

public class DisparoDesdeCrosshair : MonoBehaviour
{
    public RectTransform crosshairUI;
    public Camera camara;
    public LayerMask capaPayaso;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicionPantalla = RectTransformUtility.WorldToScreenPoint(null, crosshairUI.position);

            Ray ray = camara.ScreenPointToRay(posicionPantalla);
            RaycastHit hit;

            Debug.Log("Disparando desde crosshair en pantalla: " + posicionPantalla);

            if (Physics.Raycast(ray, out hit, 100f, capaPayaso))
            {
                Debug.Log("Impactó a: " + hit.collider.name);
                PayasoObjetivo objetivo = hit.collider.GetComponent<PayasoObjetivo>();
                if (objetivo != null)
                {
                    objetivo.Eliminar();
                }
            }
            else
            {
                Debug.Log("No impactó a ningún payaso desde crosshair.");
            }
        }
    }
}