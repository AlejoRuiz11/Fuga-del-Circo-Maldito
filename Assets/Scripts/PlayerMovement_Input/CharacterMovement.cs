using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Transform player; // Referencia al objeto del jugador
    [SerializeField] private Transform cineMachineCamera; // Referencia a la CinemachineCamera
    [SerializeField] private Transform head;
    [SerializeField] private Transform arm;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }

    // Método para mover al personaje
    public void Move(Vector3 input)
    {
        Vector3 moveDirection = (player.right * input.x + player.up * input.y + player.forward * input.z).normalized;
        /*Debug.Log(input.y);
        if(input.y != -1)
        {
            
        }*/
        moveDirection.y = player.up.y * input.y;
        moveDirection.x *= speed;
        moveDirection.z *= speed;


            // Modificando Transform
            //player.position += moveDirection * speed * Time.deltaTime;

            // Modificando Rigidbody
            //Vector3 velocity = moveDirection * speed;
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);

            // Modificando Character Controller
            characterController.Move(moveDirection * Time.deltaTime);
        
       

    }

    private void LateUpdate()
    {
        // Hacer que el personaje rote en el eje Y según la cámara
        
        player.rotation = Quaternion.Euler(0f, cineMachineCamera.eulerAngles.y, 0f);
        head.rotation = Quaternion.Euler(cineMachineCamera.eulerAngles.x, cineMachineCamera.eulerAngles.y, 0f);
        arm.rotation = Quaternion.Euler(cineMachineCamera.eulerAngles.x, cineMachineCamera.eulerAngles.y, 0f);
        
        //cineMachineCamera.position = head.position;
    }
}
