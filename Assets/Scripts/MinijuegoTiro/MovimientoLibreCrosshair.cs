using UnityEngine;

public class MovimientoLibreCrosshair : MonoBehaviour
{
    void Update()
    {
        Vector3 posicionMouse = Input.mousePosition;
        transform.position = posicionMouse;
    }
}