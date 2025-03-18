using UnityEngine;

public class TriggerCubito : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Cubito");
        }
    }
}
