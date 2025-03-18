using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private float InteractionRange = 2f;

    public void Interact()
    {
        Ray r = new Ray(InteractorSource.transform.position, InteractorSource.transform.forward);
        if(Physics.Raycast(r, out RaycastHit hit, InteractionRange))
        {
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
