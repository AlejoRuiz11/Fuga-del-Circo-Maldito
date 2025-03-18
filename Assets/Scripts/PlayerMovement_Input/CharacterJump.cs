using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private Transform groundAux;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private float jumpHeight = 1f;
    private float gravity = 9.81f;
    [SerializeField] private float verticalVelocity = 0f;
    [SerializeField] private bool isGrounded;

    private void Update()
    {
        CheckGrounded();
        Vector3 move = new Vector3(0,VerticalForceCalculation(),0);
        characterMovement.Move(move);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(groundAux.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    public void Jump()
    {
        Debug.Log("Jump");
        if(isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            Vector3 move = new Vector3(0,verticalVelocity,0);
            characterMovement.Move(move);
            Debug.Log("Salte");
        }
    }

    private float VerticalForceCalculation()
    {
        if(isGrounded)
        {
            verticalVelocity = -1f;
/*
            if(Input.GetKey(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            }*/
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

}
