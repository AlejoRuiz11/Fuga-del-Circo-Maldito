using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private float InteractionRange = 3f;
    [SerializeField] private LayerMask interactionLayer;
 
    private IInteractable currentInteractable;
    

    public void Interact()
    {
        currentInteractable?.Interact();
        /*
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit[] hits = Physics.RaycastAll(r, InteractionRange);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit.collider.gameObject.layer);
            Debug.Log(interactionLayer);
            if(interactionLayer == hit.collider.gameObject.layer)
            {
                
                
            }
        }*/
    }

    void Update()
    {
        //Debug.Log(interactionLayer.value);
        /*
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit[] hits = Physics.RaycastAll(r, InteractionRange);
        
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Player")) continue;

            if (hits[1].collider.CompareTag("Interactable"))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactable.Interact();
                a = true;
                return;
            }
        }*/

        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        RaycastHit[] hits = Physics.RaycastAll(r, InteractionRange);
        bool aux = false;
        foreach (RaycastHit hit in hits)
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                SetNewCurrentInteractable(interactable);
                aux = true;
                break;
            }
        }
        if(aux == false)
        {
            DisableCurrentInteractable();
        }

    }

    void SetNewCurrentInteractable(IInteractable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();   
    }

    void DisableCurrentInteractable()
    {
        if(currentInteractable != null)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }


}
