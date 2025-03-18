using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraRoot; // Objeto que controla la rotación de la cámara
    public float sensitivity = 200f; // Sensibilidad del mouse
    public float smoothTime = 0.00001f; 
    private CinemachinePanTilt pov;
    public CinemachineCamera virtualCamera;

    private float xRotation = 0f;
    private float yRotation = 0f;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro
        //pov = virtualCamera.GetCinemachineComponent<CinemachinePanTilt>();

    }


    void Update()
    {/**
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation = Mathf.Lerp(yRotation, yRotation + mouseX, smoothTime);

        xRotation = Mathf.Lerp(xRotation, xRotation - mouseY, smoothTime);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rota el jugador en el eje Y (gira izquierda/derecha)
        transform.Rotate(Vector3.up * mouseX);
/*
        // Rota la cámara en el eje X (mueve arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);*/
        //cameraRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
