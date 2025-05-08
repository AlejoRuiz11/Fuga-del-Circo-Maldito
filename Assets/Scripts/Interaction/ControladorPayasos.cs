using UnityEngine;
using TMPro;

public class ControladorPayasos : MonoBehaviour
{
    public static ControladorPayasos Instancia;

    public GameObject prefabPayaso;
    public int cantidadImpactos = 0;
    public Transform[] zonasDeSpawn; // Lugares donde puede aparecer el payaso
    public TextMeshProUGUI textoContador;

    private int aciertos = 0;
    private float tiempoLimite = 10f;
    private float tiempoRestante;
    private bool juegoActivo = false;

    private GameObject payasoActual;

    void Awake()
    {
        Instancia = this;
    }

    void OnEnable()
    {
        tiempoRestante = tiempoLimite;
        juegoActivo = true;
        SpawnPayaso();
    }

    void Update()
    {
        if (!juegoActivo) return;

        tiempoRestante -= Time.deltaTime;
        textoContador.text = "Payasos eliminados: " + aciertos;

        if (tiempoRestante <= 0)
        {
            juegoActivo = false;
            textoContador.text += "\nFin del juego";
            if (payasoActual) Destroy(payasoActual);
        }

        // Disparo con clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                PayasoObjetivo p = hit.collider.GetComponent<PayasoObjetivo>();
                if (p != null)
                {
                    p.SerDisparado();
                }
            }
        }
    }

    void SpawnPayaso()
    {
        if (!juegoActivo) return;

        if (zonasDeSpawn.Length == 0)
        {
            Debug.LogWarning("No hay zonas de spawn asignadas");
            return;
        }

        int indice = Random.Range(0, zonasDeSpawn.Length);
        Vector3 posicion = zonasDeSpawn[indice].position;
        payasoActual = Instantiate(prefabPayaso, posicion, Quaternion.identity);
    }

    public void RegistrarAcierto()
    {
        aciertos++;
        SpawnPayaso();
    }

    public void RegistrarImpacto()
    {
        cantidadImpactos++;
        textoContador.text = "Impactos: " + cantidadImpactos;
    }
}