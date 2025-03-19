using UnityEngine;

public class TriggerFirstManiqui : MonoBehaviour
{
    //[SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject manikin;
    void Start()
    {
        //audioSource.PlayOneShot(audioSource.clip, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            manikin.SetActive(true);
            //audioSource.PlayOneShot(audioSource.clip, 0.5f);
        }
    }
}
