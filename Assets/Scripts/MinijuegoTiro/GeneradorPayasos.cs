using UnityEngine;
using TMPro;

public class GeneradorPayasos : MonoBehaviour
{
    public static GeneradorPayasos Instance; // Singleton

    public GameObject prefabPayaso;
    public float tiempoEntrePayasos = 0.3f;
    public int cantidadMaxima = 60;

    public TextMeshProUGUI textoContador;
    private int cantidadActual = 0;
    private int cantidadEliminados = 0;
    private float tiempoSiguiente = 0f;
    private bool activo = false;

    void Awake()
    {
        Instance = this;
    }

    public void IniciarGenerador()
    {
        activo = true;
        tiempoSiguiente = 0f;
        cantidadActual = 0;
        cantidadEliminados = 0;

        if (textoContador != null)
            textoContador.text = "Payasos eliminados: 0";
    }

    void Update()
    {
        if (!activo) return;

        tiempoSiguiente -= Time.deltaTime;

        if (tiempoSiguiente <= 0f && cantidadActual < cantidadMaxima)
        {
            float x = Random.Range(-4.5f, 4.5f);
            float y = Random.Range(1f, 3.5f);
            float z = Random.Range(-4.5f, -0.5f);

            Vector3 posicion = new Vector3(x, y, z);
            Quaternion rotacion = Quaternion.Euler(0, 180, 0);

            Instantiate(prefabPayaso, posicion, rotacion);
            cantidadActual++;
            tiempoSiguiente = tiempoEntrePayasos;
        }
    }

    public void RegistrarAcierto()
    {
        cantidadEliminados++;

        if (textoContador != null)
            textoContador.text = "Payasos eliminados: " + cantidadEliminados;
    }

    public int GetCantidadEliminados()
    {
        return cantidadEliminados;
    }
}