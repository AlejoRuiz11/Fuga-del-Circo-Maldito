using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelConfirmacionSalida;
    public GameObject panelConfirmacionGuardado;
    public GameObject screenInstructions;
    public GameObject panelPausa;

    private bool juegoPausado = false;

    void Start()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
        panelConfirmacionGuardado.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReanudarJuego()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;

        // Detectar en qué escena estamos
        string nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "MinijuegoTiro")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined; // permite mover libremente el cursor dentro de la ventana
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; // solo para Scene2
        }
    }

    public void SalirDelJuego()
    {
        panelConfirmacionSalida.SetActive(true);
    }

    public void ConfirmarSalida()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicio");
    }

    public void CancelarSalida()
    {
        panelConfirmacionSalida.SetActive(false);
    }

    public void MostrarConfirmacionGuardar()
    {
        panelConfirmacionGuardado.SetActive(true);
    }

    public void ConfirmarGuardado()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerPrefs.SetFloat("PosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PosZ", player.transform.position.z);
            PlayerPrefs.SetInt("TienePartidaGuardada", 1);
            Debug.Log("Partida guardada exitosamente.");
        }
        panelConfirmacionGuardado.SetActive(false);
    }

    public void CancelarGuardado()
    {
        panelConfirmacionGuardado.SetActive(false);
    }
        public void MostrarInstrucciones()
    {
        panelPausa.SetActive(false);
        screenInstructions.SetActive(true);
    }
        public void CerrarInstruccionesScene2()
    {
        screenInstructions.SetActive(false);
        panelPausa.SetActive(true);
    }
}