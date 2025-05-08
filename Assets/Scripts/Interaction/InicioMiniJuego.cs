using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class InicioMinijuego : MonoBehaviour
{
    public GameObject textoInstruccion;
    public GameObject textoCuentaRegresiva;
    public GameObject textoContador;

    public GameObject controladorPayasos; // El script que manejará los payasos (lo activamos al final)

    private bool juegoIniciado = false;

    void Start()
    {
        textoInstruccion.SetActive(true);
        textoCuentaRegresiva.SetActive(false);
        textoContador.SetActive(false);
        controladorPayasos.SetActive(false); // Desactivado hasta que comience el juego
    }

    void Update()
    {
        if (!juegoIniciado && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(EmpezarCuentaRegresiva());
            juegoIniciado = true;
        }
    }

    IEnumerator EmpezarCuentaRegresiva()
    {
        textoInstruccion.SetActive(false);
        textoCuentaRegresiva.SetActive(true);
        TextMeshProUGUI txt = textoCuentaRegresiva.GetComponent<TextMeshProUGUI>();

        for (int i = 3; i > 0; i--)
        {
            txt.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        textoCuentaRegresiva.SetActive(false);
        textoContador.SetActive(true);
        controladorPayasos.SetActive(true); // Activamos el script de los payasos
    }
}