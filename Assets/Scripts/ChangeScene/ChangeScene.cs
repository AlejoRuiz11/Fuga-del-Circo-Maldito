using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject screenInicio;
    public GameObject screenConfig;
    public GameObject screenCredits;
    public GameObject screenInstructions;
    [SerializeField] private AudioSource audioSource;

    public Button botonContinuar;
    public Button botonNuevaPartida;

    void Start()
    {
        if (botonContinuar != null && botonNuevaPartida != null)
        {
            if (PlayerPrefs.GetInt("TienePartidaGuardada", 0) == 1)
            {
                botonContinuar.gameObject.SetActive(true);
                botonNuevaPartida.GetComponentInChildren<Text>().text = "Iniciar nueva partida";
            }
            else
            {
                botonContinuar.gameObject.SetActive(false);
                botonNuevaPartida.GetComponentInChildren<Text>().text = "Jugar";
            }
        }
    }
    public void CargarEscena()
    {
        // Limpiar datos de partida guardada
        PlayerPrefs.DeleteKey("TienePartidaGuardada");
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");

        // Reiniciar vida y marcar como nueva partida
        PlayerPrefs.SetFloat("VidaActual", 100f);
        PlayerPrefs.SetInt("NuevaPartida", 1);
        PlayerPrefs.Save();

        audioSource.Stop();
        SceneManager.LoadScene("Scene2");
    }

    public void ContinuarPartida()
    {
        audioSource.Stop();
        SceneManager.LoadScene("Scene2");
    }
    public void MostrarConfiguracion()
    {
        screenInicio.SetActive(false);
        screenConfig.SetActive(true);
    }

    public void CerrarConfiguracion()
    {
        screenConfig.SetActive(false);
        screenInicio.SetActive(true);

    }

    public void MostrarCreditos()
    {
        screenInicio.SetActive(false);
        screenCredits.SetActive(true);
    }

    public void CerrarCreditos()
    {
        screenCredits.SetActive(false);
        screenInicio.SetActive(true);
    }

    public void MostrarInstrucciones()
    {
        screenInicio.SetActive(false);
        screenInstructions.SetActive(true);
    }
    
    public void CerrarInstrucciones()
    {
        screenInstructions.SetActive(false);
        screenInicio.SetActive(true);
    }
}