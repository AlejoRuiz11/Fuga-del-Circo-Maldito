using UnityEngine;
using TMPro;

public class Puerta : MonoBehaviour
{
    [SerializeField] private Animator puerta;
    [SerializeField] private TextMeshProUGUI textoPuerta;
    [SerializeField] private AudioClip sonidoAbrir;
    [SerializeField] private AudioClip sonidoCerrar;
    [SerializeField] private AudioSource audioSource;

    private bool jugadorCerca = false;
    private bool puertaAbierta = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            puertaAbierta = !puertaAbierta;
            puerta.SetBool("PuertaActiv", puertaAbierta);

            // Reproducir el sonido correspondiente
            if (puertaAbierta)
            {
                audioSource.PlayOneShot(sonidoAbrir);
            }
            else
            {
                audioSource.PlayOneShot(sonidoCerrar);
            }

            textoPuerta.text = ""; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            textoPuerta.text = "Presiona E para abrir/cerrar la puerta";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            textoPuerta.text = "";
        }
    }
}
