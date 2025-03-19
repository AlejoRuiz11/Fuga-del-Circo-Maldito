using System;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    public InteractionHover interactionHover { get; }
    public String message { get; }
    void Interact();
    void DisableOutline();
    void EnableOutline();
}

