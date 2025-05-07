using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntajeDiana : MonoBehaviour
{
    [SerializeField] private TMP_Text textoPuntaje;

    public void CalcularPuntaje(Vector3 direccion)
    {
        Ray ray = new Ray(Camera.main.transform.position, direccion);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            int puntos = 0;

            switch (hit.collider.tag)
            {
                case "Anillo10": puntos = 10; break;
                case "Anillo8": puntos = 8; break;
                case "Anillo6": puntos = 6; break;
                case "Anillo4": puntos = 4; break;
                case "Anillo2": puntos = 2; break;
                default: puntos = 0; break;
            }

            textoPuntaje.text = "¡Puntaje: " + puntos + "!";
            Debug.Log("Impacto en: " + hit.collider.name + " - Puntaje: " + puntos);
        }
    }
}