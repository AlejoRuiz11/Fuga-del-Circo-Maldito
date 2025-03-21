using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject screenInicio;
    public GameObject screenConfig;
    public GameObject screenCredits;
    public GameObject screenInstructions;

    public void CargarEscena()
    {
        SceneManager.LoadScene("Scene1");
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