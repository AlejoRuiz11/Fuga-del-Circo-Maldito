using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform jugador;
    public Animator animator;
    public float velocidadRotacion = 2f;
    public AudioSource audioSource;
    public bool enZonaSegura = false;
    public bool enZonaJumpScare = false;

    private bool empezoJumpScare = false;
    private bool yaHizoDanio = false;
    private bool enCooldown = false;

    [SerializeField] private GameObject playerFlashLight;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private GameObject JumpscareCamera;
    [SerializeField] private AudioSource audioSourceJumpScare;
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private LayerMask capaParedes;
    [SerializeField] private float distanciaDeteccion = 1f;

    [Header("Vida y Derrota")]
    [SerializeField] private ControladorVida controladorVida;
    [SerializeField] private GameObject panelMuerte;

    [Header("Mensaje Zafarse")]
    [SerializeField] private GameObject mensajeZafarse;

    void Update()
    {
        if ((jugador == null || Camera.main == null || enZonaSegura) && !empezoJumpScare)
        {
            animator.speed = 0f;
            if (audioSource.isPlaying) audioSource.Stop();
            return;
        }

        if (enZonaJumpScare && !empezoJumpScare && !enCooldown)
        {
            audioSourceJumpScare.PlayOneShot(audioSourceJumpScare.clip, 0.5f);
            animator.SetBool("Jumpscare", true);
            empezoJumpScare = true;
            animator.speed = 1f;

            cameraController.enemyTransform = transform;
            cameraController.sensitivity = 0f;
            cameraController.jumpScare = true;
            characterMovement.jumpScare = true;

            if (!yaHizoDanio)
            {
                controladorVida.ReducirVida(25f);
                mensajeZafarse.SetActive(true);
                yaHizoDanio = true;

                if (controladorVida.GetVidaActual() <= 0 && panelMuerte != null)
                {
                    panelMuerte.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }

            StartCoroutine(JumpScare());
            return;
        }

        if (empezoJumpScare && Input.GetKeyDown(KeyCode.E))
        {
            FinalizarJumpScare();
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        bool estaEnPantalla = viewPos.z > 0 && viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1;

        if (!estaEnPantalla)
        {
            Vector3 direccion = transform.forward;
            bool hayParedAdelante = Physics.Raycast(transform.position, direccion, distanciaDeteccion, capaParedes);

            Vector3 objetivo = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            Vector3 direccion1 = (objetivo - transform.position).normalized;

            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion1);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);

            if (!audioSource.isPlaying) audioSource.Play();
            animator.speed = hayParedAdelante ? 0f : 1f;
        }
        else
        {
            animator.speed = 0f;
            if (audioSource.isPlaying) audioSource.Stop();
        }
    }

    private IEnumerator JumpScare()
    {
        yield return new WaitForSeconds(0.5f);
        playerFlashLight.SetActive(false);
        JumpscareCamera.SetActive(true);
        mainCamera.enabled = false;
    }

    private void FinalizarJumpScare()
    {
        empezoJumpScare = false;
        yaHizoDanio = false;
        enCooldown = true;

        animator.SetBool("Jumpscare", false);
        JumpscareCamera.SetActive(false);
        mainCamera.enabled = true;
        playerFlashLight.SetActive(true);
        mensajeZafarse.SetActive(false);

        cameraController.jumpScare = false;
        characterMovement.jumpScare = false;
        cameraController.sensitivity = 200f;

        StartCoroutine(CooldownTiempo());
    }

    private IEnumerator CooldownTiempo()
    {
        yield return new WaitForSeconds(2f);
        enCooldown = false;
    }
}