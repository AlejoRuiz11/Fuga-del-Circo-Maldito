using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarMinijuego : MonoBehaviour
{
    public string nombreEscenaMinijuego = "MinijuegoTiro";
    private bool jugadorDentro = false;

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nombreEscenaMinijuego);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }
}