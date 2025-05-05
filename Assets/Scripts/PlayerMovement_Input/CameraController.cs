using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform visualBody;
    public Transform hand;
    public Transform _camera;
    public float sensitivity = 200f; // Sensibilidad del mouse
    public float cameraAcceleration= 5.0f; 

    private float xRotation = 0f;
    private float yRotation = 0f;
    public bool jumpScare = false;
    public Transform enemyTransform;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro
        //pov = virtualCamera.GetCinemachineComponent<CinemachinePanTilt>();

    }


    void Update()
    {
        /*float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation = Mathf.Lerp(yRotation, yRotation + mouseX, smoothTime);

        xRotation = Mathf.Lerp(xRotation, xRotation - mouseY, smoothTime);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);*/

        if(!jumpScare)
        {
            xRotation += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            hand.localRotation = Quaternion.Euler(-xRotation, yRotation, 0);

            transform.localRotation = Quaternion.Lerp(transform.localRotation,
            Quaternion.Euler(0, yRotation, 0), cameraAcceleration * Time.deltaTime);

            visualBody.localRotation = Quaternion.Lerp(visualBody.localRotation,
            Quaternion.Euler(0, yRotation, 0), cameraAcceleration * Time.deltaTime);

            _camera.localRotation = Quaternion.Lerp(_camera.localRotation,
            Quaternion.Euler(-xRotation, 0, 0), cameraAcceleration * Time.deltaTime);
        }
        else
        {
            Vector3 directionToEnemy = enemyTransform.position - transform.position;
            directionToEnemy.y = 0; // Opcional: evita mirar hacia arriba o abajo

            Quaternion lookRotation = Quaternion.LookRotation(directionToEnemy);

            // Aplica la rotación al cuerpo visual, al transform y a la cámara
            hand.localRotation = Quaternion.Lerp(hand.localRotation,Quaternion.Euler(0, lookRotation.eulerAngles.y + 90f, 0),cameraAcceleration * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, cameraAcceleration * Time.deltaTime);
            visualBody.localRotation = Quaternion.Lerp(visualBody.localRotation, Quaternion.Euler(0, lookRotation.eulerAngles.y, 0), cameraAcceleration * Time.deltaTime);
            _camera.localRotation = Quaternion.Lerp(_camera.localRotation, Quaternion.Euler(0, 0, 0), cameraAcceleration * Time.deltaTime); // Puedes ajustar esto si querés una mirada específica

            Debug.Log("JumpScare: girando hacia el enemigo");
        }

    }
}
