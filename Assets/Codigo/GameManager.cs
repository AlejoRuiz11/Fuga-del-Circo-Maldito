using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 



public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    private Tablero m_Tablero;
    

    private bool m_PuedeSeleccionarFicha = true;
    private Ficha m_UltimaSeleccion = null;

    [SerializeField] private int m_IntentosRestantes = 10;
    [SerializeField] AudioSource m_SoundFX;
    [SerializeField] AudioClip m_SonidoAcierto;
    [SerializeField] AudioClip m_SonidoError;
    [SerializeField] private TextMeshPro m_TextoIntentos;

    private void Awake()
    {
        Singleton();
        m_Tablero = GetComponent<Tablero>();
    }

    void Start()
    {
        m_Tablero.InicializarTablero();
        ActualizarTextoIntentos();
    }

    public void ProcesarClickEnFicha(Ficha ficha)
    {
        if (!m_PuedeSeleccionarFicha)
            return;

        if (!m_UltimaSeleccion)
        {
            PrimeraFichaSeleccionada(ficha);
        }
        else
        {
            SegundaFichaSeleccionada(ficha);        }
    }

    private void PrimeraFichaSeleccionada(Ficha ficha)
    {
        m_UltimaSeleccion = ficha;
        ficha.MostrarFrente();
    }

    private void SegundaFichaSeleccionada(Ficha ficha)
    {
        if (ficha == m_UltimaSeleccion)
            return;

        ficha.MostrarFrente();

        if (ficha.Id == m_UltimaSeleccion.Id)
        {
            ParCorrecto(ficha, m_UltimaSeleccion);
        }
        else
        {
            ParIncorrecto(ficha, m_UltimaSeleccion);
        }
    }

    private void ParCorrecto(Ficha ficha, Ficha ultimaSeleccion)
    {
        Destroy(ficha.gameObject, 1.5f);
        Destroy(ultimaSeleccion.gameObject, 1.5f);

        if(m_SonidoAcierto != null)
        {
            m_SoundFX.PlayOneShot(m_SonidoAcierto);
        }

        m_UltimaSeleccion = null;

        StartCoroutine(BloquearSeleccionPorTiempo(1.5f));

        m_Tablero.m_FichasRestantes -= 2;
        
        if (m_Tablero.m_FichasRestantes <= 0)
        {
            //TODO Ganamos
        }
    }

    private void ParIncorrecto(Ficha ficha, Ficha ultimaSeleccion)
    {
        m_UltimaSeleccion = null;
        m_IntentosRestantes -= 1;
        ActualizarTextoIntentos();

        if (m_SonidoError != null)
        {
            m_SoundFX.PlayOneShot(m_SonidoError);
        }

        if (m_IntentosRestantes <= 0)
        {
            m_PuedeSeleccionarFicha = false;

            StartCoroutine(ReiniciarTrasDelay(1.5f));
        }
        else
        {
            ficha.Invoke("MostrarReverso", 1.5f);
            ultimaSeleccion.Invoke("MostrarReverso", 1.5f);
            StartCoroutine(BloquearSeleccionPorTiempo(1.5f));
        }
    }



    private void Singleton()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BloquearSeleccionPorTiempo(float tiempo)
    {
        m_PuedeSeleccionarFicha = false;
        yield return new WaitForSeconds(tiempo);
        m_PuedeSeleccionarFicha = true;
    }

    public void ReiniciarJuego()
    {
        m_IntentosRestantes = 10;
        ActualizarTextoIntentos();
        m_UltimaSeleccion = null;
        m_PuedeSeleccionarFicha = true;

        foreach (Transform child in m_Tablero.GetAreaDeJuego())
        {
            Destroy(child.gameObject);
        }

        m_Tablero.InicializarTablero();
    }

    IEnumerator ReiniciarTrasDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReiniciarJuego();
    }

    private void ActualizarTextoIntentos()
    {
        m_TextoIntentos.text = "Intentos restantes: " + m_IntentosRestantes;
    }


}


