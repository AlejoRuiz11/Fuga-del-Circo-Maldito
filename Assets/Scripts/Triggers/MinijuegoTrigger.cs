using UnityEngine;

public class MinijuegoTrigger : MonoBehaviour
{
    public GameObject mensajeUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(false);
        }
    }
}