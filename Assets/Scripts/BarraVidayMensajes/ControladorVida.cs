using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class ControladorVida : MonoBehaviour
{
    public Image barraVida;
    public TextMeshProUGUI textoVida;

    private float vidaActual;
    private float vidaMaxima = 100f;

    [SerializeField] private GameObject canvasMuerte;

    void Start()
    {
        if (PlayerPrefs.GetInt("NuevaPartida", 0) == 1)
        {
            vidaActual = vidaMaxima;
            PlayerPrefs.DeleteKey("NuevaPartida");
            PlayerPrefs.SetFloat("VidaActual", vidaActual);
            PlayerPrefs.Save();
        }
        else
        {
            vidaActual = PlayerPrefs.GetFloat("VidaActual", vidaMaxima);
        }
        ActualizarBarraVida();
        Debug.Log("Controlador vida inicia con : " + vidaActual);
    }

    public void ReducirVida(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
        ActualizarBarraVida();

        if (vidaActual <= 0)
        {
            Debug.Log("Jugador murió");
            if (canvasMuerte != null)
            {
                canvasMuerte.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Time.timeScale = 0f;
            // Aquí podrías activar el CanvasMuerte si quieres hacerlo ahora
        }
    }

    private void ActualizarBarraVida()
    {
        Debug.Log("Vida actual: " + vidaActual);
        if (barraVida != null)
        {
            barraVida.fillAmount = vidaActual / vidaMaxima;
        }

        if (textoVida != null)
        {
            textoVida.text = Mathf.RoundToInt((vidaActual / vidaMaxima) * 100f).ToString() + "%";
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("VidaActual", vidaActual);
        PlayerPrefs.Save();
    }

    void OnEnable()
    {
        vidaActual = PlayerPrefs.GetFloat("VidaActual", vidaMaxima);
        ActualizarBarraVida();
    }

    public float GetVidaActual()
    {
        return vidaActual;
    }    
}