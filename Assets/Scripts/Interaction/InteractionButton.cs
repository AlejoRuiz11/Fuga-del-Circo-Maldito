using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionHover interactionHover1;
    public String message1;
    public UnityEvent OnInteract;

    public String message { get => message1; }
    public InteractionHover interactionHover { get => interactionHover1; }
    private bool done = false;

    private void Start()
    {
        DisableOutline();
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
        if (!done)
        {
            OnInteract.Invoke();
            Debug.Log("Activar gas");
            done = true;
        }

    }
    
    public void IsDone()
    {
        done = true;
    }
}
