using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerConEvento : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("¿Cuánto tiempo esperar antes de ejecutar el evento?")]
    [SerializeField] private float tiempoDeRetraso = 0f;

    [Tooltip("¿Solo una vez?")]
    [SerializeField] private bool soloUnaVez = true;

    [Header("Evento que se ejecutará")]
    public UnityEvent eventoAlActivar;

    private bool yaActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!soloUnaVez || !yaActivado))
        {
            yaActivado = true;

            if (tiempoDeRetraso > 0f)
                Invoke(nameof(EjecutarEvento), tiempoDeRetraso);
            else
                EjecutarEvento();
        }
    }

    private void EjecutarEvento()
    {
        eventoAlActivar?.Invoke();
    }
}
