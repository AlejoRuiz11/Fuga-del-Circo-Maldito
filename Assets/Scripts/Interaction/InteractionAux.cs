using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class InteractionAux : MonoBehaviour,IInteractable
{
    [SerializeField] private InteractionHover interactionHover1;
    public String message1;
    public UnityEvent OnInteract;

    public String message { get => message1; }
    public InteractionHover interactionHover { get => interactionHover1; }
    
    
    private void Start() {
        StartCoroutine(Aux());
    }


    private IEnumerator Aux() {
        yield return new WaitForSeconds(0.01f);
        EnableOutline();
        Interact();
        
    }

    public void DisableOutline()
    {
        interactionHover1.HideText();
    }

    public void EnableOutline()
    {
        interactionHover1.ShowText(message1);
    }

    public void Interact()
    {
        DisableOutline();
        OnInteract.Invoke();
        Debug.Log("Flashlight");
    }
}

