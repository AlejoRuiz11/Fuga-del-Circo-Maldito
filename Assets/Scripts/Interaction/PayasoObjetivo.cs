using UnityEngine;

public class PayasoObjetivo : MonoBehaviour
{
    public void SerDisparado()
    {
        Destroy(gameObject);
        ControladorPayasos.Instancia.RegistrarAcierto();
    }
}