using UnityEngine;
using TMPro;

public class RecogerArma : MonoBehaviour
{
    [SerializeField] private GameObject armaEnMano;
    [SerializeField] private GameObject armaSuelo;
    [SerializeField] private TextMeshProUGUI textoArma;

    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            armaEnMano.SetActive(true);       // Mostrar arma en mano
            armaSuelo.SetActive(false);       // Ocultar arma en el piso
            textoArma.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            textoArma.text = "Presiona E para recoger el arma";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            textoArma.text = "";
        }
    }
}