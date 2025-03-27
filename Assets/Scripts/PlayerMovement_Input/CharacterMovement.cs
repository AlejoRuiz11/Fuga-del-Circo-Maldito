using Unity.Cinemachine;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;

    public float walkSpeed = 3.5f;
    public float runSpeed = 7f;
    

    [SerializeField] private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    //[SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Transform player; // objeto con el cual detectara el forward ******C
    [SerializeField] private Transform playerAllBody;
    [SerializeField] private Transform cineMachineCamera; // Referencia a la CinemachineCamera
    [SerializeField] private Transform head;
    [SerializeField] private Transform arm;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false;
    }

    public void setSpeed(float amplitudGain, float frequencyGain, float speed1)
    {
        /*
        float duration = 0.5f;
        float t = 1 - Mathf.Exp(-Time.deltaTime / duration);

        cinemachineBasicMultiChannelPerlin.AmplitudeGain = Mathf.Lerp(
            cinemachineBasicMultiChannelPerlin.AmplitudeGain, amplitudGain, t
        );

        cinemachineBasicMultiChannelPerlin.FrequencyGain = Mathf.Lerp(
            cinemachineBasicMultiChannelPerlin.FrequencyGain, frequencyGain, t
        );

        speed = Mathf.Lerp(speed, speed1, t);*/
        speed = speed1;
    }

    // Método para mover al personaje
    public void Move(Vector3 input)
    {
        Vector3 forward1 = player.forward;
        forward1.y = 0; // Eliminamos la componente vertical
        forward1.Normalize(); // Normalizamos nuevamente

        Vector3 moveDirection = (player.right * input.x + playerAllBody.up * input.y + forward1 * input.z).normalized;
        //Vector3 moveDirection = (player.right * input.x + player.up * input.y + player.forward * input.z).normalized; // *****C
       
        moveDirection.y = playerAllBody.up.y * input.y; // *****CNueeva
        //moveDirection.y = player.up.y * input.y; // *****C
        
        moveDirection.x *= speed;
        moveDirection.z *= speed;


            // Modificando Transform
            //player.position += moveDirection * speed * Time.deltaTime;

            // Modificando Rigidbody
            //Vector3 velocity = moveDirection * speed;
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);

            // Modificando Character Controller
            //characterController.Move(moveDirection.normalized * 5 * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);

    }

    private void LateUpdate()
    {
        //Movimiento normal *****C
    /*
        player.rotation = Quaternion.Euler(0f, cineMachineCamera.eulerAngles.y, 0f);
        head.rotation = Quaternion.Euler(cineMachineCamera.eulerAngles.x, cineMachineCamera.eulerAngles.y, 0f);
        arm.rotation = Quaternion.Euler(cineMachineCamera.eulerAngles.x, cineMachineCamera.eulerAngles.y, 0f);
        */
    }
}
