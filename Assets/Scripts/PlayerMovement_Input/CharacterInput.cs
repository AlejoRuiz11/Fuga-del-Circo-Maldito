using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] private CharacterJump characterJump;
    [SerializeField] private Transform player; // Referencia al objeto del jugador

    //[SerializeField] private Transform cameraTransform;
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode back = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode interact = KeyCode.E;
    [SerializeField] private KeyCode jump = KeyCode.Space;


    void Update()
    {
        Vector3 moveInput = Vector3.zero;
        //moveInput.y = -1f;
        if (Input.GetKey(forward)) moveInput.z += 1;
        if (Input.GetKey(back)) moveInput.z -= 1;
        if (Input.GetKey(left)) moveInput.x -= 1;
        if (Input.GetKey(right)) moveInput.x += 1;

        if(Input.GetKey(jump)) characterJump.Jump();

        if (Input.GetKey(interact)) playerInteraction.Interact();

        if(Input.GetKey(forward) || Input.GetKey(back) || Input.GetKey(left) || Input.GetKey(right))
        {
            moveInput = moveInput.normalized;
            characterMovement.Move(moveInput);
        }
        //moveInput = moveInput.normalized;
        //characterMovement.Move(moveInput);

    }
}
