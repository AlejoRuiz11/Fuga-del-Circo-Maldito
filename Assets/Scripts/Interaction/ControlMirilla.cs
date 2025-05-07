using UnityEngine;
using UnityEngine.UI;

public class ControlMirilla : MonoBehaviour
{
    public GameObject prefabFlecha;
    public Transform puntoDisparo;

    public RectTransform mirillaUI;
    private float tiempoPresionado = 0f;
    private bool presionando = false;

    private Vector2 posicionObjetivo;
    private Vector2 posicionActual;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        posicionActual = Input.mousePosition;
    }

    void Update()
    {
        Vector2 posicionMouse = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            presionando = true;
            tiempoPresionado += Time.deltaTime;

            // Intensidad desde el inicio
            float intensidad = Mathf.Clamp01(tiempoPresionado / 7f);
            float delay = Mathf.Lerp(1f, 1f, intensidad); // el delay crece lentamente

            // La mira persigue con retraso al puntero
            posicionObjetivo = posicionMouse;
            posicionActual = Vector2.Lerp(posicionActual, posicionObjetivo, Time.deltaTime / delay);
            mirillaUI.position = posicionActual;

            if (tiempoPresionado >= 7f)
            {
                Disparar();
            }
        }
        else
        {
            presionando = false;
            tiempoPresionado = 0f;

            posicionActual = posicionMouse;
            mirillaUI.position = posicionActual;
        }

        if (Input.GetMouseButtonUp(0) && presionando)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        tiempoPresionado = 0f;
        presionando = false;

        Vector3 direccion = Camera.main.ScreenPointToRay(mirillaUI.position).direction;
        FindObjectOfType<PuntajeDiana>().CalcularPuntaje(direccion);

        // Instanciar la flecha
        GameObject flecha = Instantiate(prefabFlecha, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = flecha.GetComponent<Rigidbody>();
        rb.linearVelocity = puntoDisparo.forward * 20f;
    }
}