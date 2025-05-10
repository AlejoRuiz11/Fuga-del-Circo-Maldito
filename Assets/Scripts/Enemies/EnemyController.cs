using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform jugador;
    public Animator animator;
    public float velocidadRotacion = 2f;
    public AudioSource audioSource;
    public bool enZonaSegura = false;
    public bool enZonaJumpScare = false;
    private bool empezoJumpScare = false;
    [SerializeField] private GameObject playerFlashLight;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private GameObject JumpscareCamera;
    [SerializeField] private AudioSource audioSourceJumpScare;
    [SerializeField] private CinemachineCamera mainCamera;
    //[SerializeField] private SafeZone safeZoneScript;

    void Update()
    {
        if ((jugador == null || Camera.main == null || enZonaSegura) && !empezoJumpScare) 
        {
            // Si está en zona segura, no hace naSda
            animator.speed = 0f;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            return;
        }
        if(enZonaJumpScare)
        {   
            audioSourceJumpScare.PlayOneShot(audioSourceJumpScare.clip, 0.5f);
            animator.SetBool("Jumpscare", true);
            //transform.position += transform.forward;

            empezoJumpScare = true;
            animator.speed = 1f;
            cameraController.enemyTransform = transform;
            cameraController.sensitivity = 0f;
            cameraController.jumpScare = true;
            characterMovement.jumpScare = true;
            //StartCoroutine(FacePlayer());
            StartCoroutine(JumpScare());
            

            return;
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        bool estaEnPantalla = viewPos.z > 0 && viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1;

        if (!estaEnPantalla)
        {
            animator.speed = 1f;
            Vector3 objetivo = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            Vector3 direccion = (objetivo - transform.position).normalized;

            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.speed = 0f;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private IEnumerator JumpScare()
    {
        yield return new WaitForSeconds(0.5f);
        playerFlashLight.SetActive(false);
        JumpscareCamera.SetActive(true);
        mainCamera.enabled = false;
        
    }
    
/*
    private IEnumerator FacePlayer()
    {
        float rotationSpeed = 3f;
        while(enZonaJumpScare)
        {
            Vector3 directionToPlayer = jugador.transform.position - transform.position;
            directionToPlayer.y = 0;

            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            jugador.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            jugador.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime * 2);

            yield return null;
        }
    }*/
}
