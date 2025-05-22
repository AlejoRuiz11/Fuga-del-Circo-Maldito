using UnityEngine;
using TMPro;
using System;

public class Puerta : MonoBehaviour
{
    [SerializeField] private Animator puerta;
    [SerializeField] private TextMeshProUGUI textoPuerta;
    [SerializeField] private AudioClip sonidoAbrir;
    [SerializeField] private AudioClip sonidoCerrar;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool hasKey = false;
    [SerializeField] private String texto;

    public bool noAbrir = false;
    private bool jugadorCerca = false;
    private bool puertaAbierta = false;

    void Update()
    {
        if (noAbrir) return;
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            AbrirCerrar();
        }
    }

    public void AbrirCerrar()
    {
        if (noAbrir) return;
        if (!hasKey) return;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hasKey)
            {
                jugadorCerca = true;
                textoPuerta.text = "Presiona E para abrir/cerrar la puerta";
            }
            else
            {
                textoPuerta.text = texto;
            }
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

    public void HasKey()
    {
        hasKey = true;
    }
}
