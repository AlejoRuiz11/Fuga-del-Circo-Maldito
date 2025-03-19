using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraRoot; // Objeto que controla la rotación de la cámara
    public Transform hand;
    public Transform _camera;
    public float sensitivity = 200f; // Sensibilidad del mouse
    public float cameraAcceleration= 5.0f; 

    private float xRotation = 0f;
    private float yRotation = 0f;



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

        
        xRotation += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        hand.localRotation = Quaternion.Euler(-xRotation, yRotation, 0);

        transform.localRotation = Quaternion.Lerp(transform.localRotation,
        Quaternion.Euler(0, yRotation, 0), cameraAcceleration * Time.deltaTime);

        _camera.localRotation = Quaternion.Lerp(_camera.localRotation,
        Quaternion.Euler(-xRotation, 0, 0), cameraAcceleration * Time.deltaTime);

    }
}
