using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform jugador;
    public Animator animator;
    public float velocidadRotacion = 2f;
    public AudioSource audioSource;
    public bool enZonaSegura = false;
    //[SerializeField] private SafeZone safeZoneScript;

    void Update()
    {
        //enZonaSegura = safeZoneScript.enZonaSegura;

        if (jugador == null || Camera.main == null || enZonaSegura) 
        {
            // Si está en zona segura, no hace naSda
            animator.speed = 0f;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
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
}
