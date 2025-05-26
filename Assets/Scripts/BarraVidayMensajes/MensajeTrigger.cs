using UnityEngine;
using TMPro;

public class MensajeTrigger : MonoBehaviour
{
    public string mensaje;
    public float duracion = 10f;
    public GameObject panelMensaje;
    public TextMeshProUGUI textoMensaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && panelMensaje != null && textoMensaje != null)
        {
            Debug.Log("Jugador ha entrado al trigger de mensaje.");
            textoMensaje.text = mensaje;
            panelMensaje.SetActive(true);
            Invoke("OcultarMensaje", duracion);
        }
    }

    void OcultarMensaje()
    {
        panelMensaje.SetActive(false);
    }
}