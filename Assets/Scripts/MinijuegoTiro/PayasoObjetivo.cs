using UnityEngine;

public class PayasoObjetivo : MonoBehaviour
{
    public void Eliminar()
    {
        Debug.Log("Impacto a payaso");
        Destroy(gameObject);
        GeneradorPayasos.Instance.RegistrarAcierto();
    }
}