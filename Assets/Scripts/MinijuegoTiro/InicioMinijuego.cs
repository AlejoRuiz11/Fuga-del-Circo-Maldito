using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InicioMinijuego : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject textoInstruccion;
    public TextMeshProUGUI textoCuentaRegresiva;
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoTiempo;
    public GameObject panelVictoria;
    public GameObject panelDerrota;


    [SerializeField] private ControladorVida controladorVida;

    [SerializeField] private GameObject barraVidaCanvas;


    public bool cronometroActivo = false;
    private bool juegoIniciado = false;
    private bool juegoTerminado = false;
    [SerializeField] private float tiempoRestante = 30f;
    [SerializeField] private int objetivoAciertos = 60;

    void Start()
    {
        textoCuentaRegresiva.gameObject.SetActive(false);
        textoInstruccion.SetActive(true);
        crosshair.SetActive(false);
        textoContador.gameObject.SetActive(false);
        textoTiempo.gameObject.SetActive(false);
        panelVictoria.SetActive(false);
        panelDerrota.SetActive(false);
        Debug.Log("Vida en inicio minijuego: " + PlayerPrefs.GetFloat("VidaActual", 100f));
    }

    void Update()
    {
        if (!juegoIniciado && Input.GetKeyDown(KeyCode.Return))
        {
            textoInstruccion.SetActive(false);
            StartCoroutine(IniciarCuentaRegresiva());
            juegoIniciado = true;
        }

        if (juegoIniciado && cronometroActivo && !juegoTerminado)
        {
            tiempoRestante -= Time.deltaTime;
            textoTiempo.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString() + " seg";

            int aciertos = GeneradorPayasos.Instance.GetCantidadEliminados();

            if (aciertos >= objetivoAciertos)
            {
                TerminarJuego(true);
            }
            else if (tiempoRestante <= 0f)
            {
                TerminarJuego(false);
            }
        }
    }

    private System.Collections.IEnumerator IniciarCuentaRegresiva()
    {
        textoCuentaRegresiva.gameObject.SetActive(true);
        textoCuentaRegresiva.text = "3";
        yield return new WaitForSeconds(1);
        textoCuentaRegresiva.text = "2";
        yield return new WaitForSeconds(1);
        textoCuentaRegresiva.text = "1";
        yield return new WaitForSeconds(1);
        textoCuentaRegresiva.gameObject.SetActive(false);

        crosshair.SetActive(true);
        textoContador.gameObject.SetActive(true);
        textoTiempo.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        GeneradorPayasos generador = FindObjectOfType<GeneradorPayasos>();
        if (generador != null)
        {
            generador.textoContador = textoContador;
            generador.IniciarGenerador();
        }
        cronometroActivo = true;
    }

    private void TerminarJuego(bool victoria)
    {
        juegoTerminado = true;
        crosshair.SetActive(false);
        textoTiempo.gameObject.SetActive(false);
        textoContador.gameObject.SetActive(false);
        Cursor.visible = true;

        if (victoria)
        {
            panelVictoria.SetActive(true);
            if (barraVidaCanvas != null)
            {
                barraVidaCanvas.SetActive(false);
            }

            PlayerPrefs.SetInt("GanoMinijuegoTiro", 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Mostrar panel derrota
            panelDerrota.SetActive(true);

            // Reducir vida
            controladorVida.ReducirVida(50f);

            // Guardar la nueva vida
            PlayerPrefs.SetFloat("VidaActual", controladorVida.GetVidaActual());
            PlayerPrefs.Save();

            Debug.Log("Derrota en minijuego. Nueva vida: " + controladorVida.GetVidaActual());

            // Mostrar canvas de muerte si corresponde
            if (controladorVida.GetVidaActual() <= 0f)
            {
                GameObject canvasMuerte = GameObject.Find("CanvasMuerte");
                if (canvasMuerte != null)
                {
                    canvasMuerte.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reintentando minijuego sin reiniciar vida");
    }

    public void Siguiente()
    {
        PlayerPrefs.SetInt("PostMiniJuego", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scene2");
        Debug.Log("seteado spawn post-minijuego");
    }
}