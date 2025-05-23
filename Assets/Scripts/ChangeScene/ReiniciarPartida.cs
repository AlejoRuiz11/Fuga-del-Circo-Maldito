using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarPartida : MonoBehaviour
{
    public string nombreEscenaInicial = "Scene2"; // Cambia si tu escena tiene otro nombre

    public void Reiniciar()
    {
        PlayerPrefs.DeleteAll(); // Limpia todos los datos guardados
        PlayerPrefs.Save();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(nombreEscenaInicial);
    }
}