using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelConfirmacionSalida;
    public GameObject panelPausa;

    private bool juegoPausado = false;

    void Start()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
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

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
}