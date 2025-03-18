using UnityEngine;

public class InteractionFlashlight: MonoBehaviour , IInteractable
{
    public void Interact()
    {
        Debug.Log("Flashlight");
    }
}
