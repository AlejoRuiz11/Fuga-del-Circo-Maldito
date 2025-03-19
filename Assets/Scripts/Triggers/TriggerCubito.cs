using UnityEngine;

public class TriggerCubito : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource.PlayOneShot(audioSource.clip, 0);
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            audioSource.Play();
        }
    }
}
