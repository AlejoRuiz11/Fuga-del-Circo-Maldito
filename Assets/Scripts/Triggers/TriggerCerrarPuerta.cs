using UnityEngine;

public class TriggerCerrarPuerta : MonoBehaviour
{
    [SerializeField] private Puerta puertaScript;
    [SerializeField] private AudioSource audioSource;
    private bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if(alreadyPlayed) return;
        if (other.gameObject.CompareTag("Player"))
        {
            puertaScript.AbrirCerrar();
            puertaScript.noAbrir = true;
            alreadyPlayed = true;
            audioSource.PlayOneShot(audioSource.clip, 1f);
        }
    }
}
