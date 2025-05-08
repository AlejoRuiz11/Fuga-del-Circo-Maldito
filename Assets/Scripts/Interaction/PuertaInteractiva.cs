using UnityEngine;
using TMPro;

public class PuertaInteractiva : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPuerta;
    public bool abierta = false;
    private bool bloqueada = false;
    private bool jugadorCerca = false;

    private Quaternion rotacionInicial;
    private Quaternion rotacionAbierta;

    void Start()
    {
        rotacionInicial = transform.rotation;
        rotacionAbierta = Quaternion.Euler(0, 90, 0) * rotacionInicial;
    }

    void Update()
    {
        if (jugadorCerca && !bloqueada && Input.GetKeyDown(KeyCode.E))
        {
            AlternarPuerta();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            textoPuerta.text = "Presiona E para abrir la puerta";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            textoPuerta.text = "";

            if (abierta)
            {
                // Se cierra automáticamente y se bloquea
                AlternarPuerta();
            }
        }
    }

    void AlternarPuerta()
    {
        abierta = !abierta;
        transform.rotation = abierta ? rotacionAbierta : rotacionInicial;

        if (!abierta)
        {
            bloqueada = true;
        }
    }
}