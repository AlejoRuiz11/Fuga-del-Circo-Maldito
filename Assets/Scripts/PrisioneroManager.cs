using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrisionerManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;


    [SerializeField] private GameObject prisionero;
    [SerializeField] private Transform transformJugador;
    [SerializeField] private GameObject manoJugador;
    [SerializeField] private Transform transformPosicionPrisionero;
    [SerializeField] private AudioSource audioSourceHistoria;
    [SerializeField] private AudioClip clipHistoria;
    [SerializeField] private InteractionButton interactionButtonGas;
    [SerializeField] private GameObject gas;
    [SerializeField] private AudioSource sonidoFondoPrincipal;
    [SerializeField] private AudioClip musicaHorrorFinal;
    [SerializeField] private AudioClip musicaCreditosFinal;
    [SerializeField] private AudioClip musicaFeliz;
    [SerializeField] private GameObject textoCreditos;
    [SerializeField] private GameObject NPCgas;
    [SerializeField] private Animator animatorNpc;

    private Coroutine currentFade;

    public void escenaFeliz()
    {
        StartCoroutine(FinalFeliz());
    }

    private IEnumerator FinalFeliz()
    {
        sonidoFondoPrincipal.Stop();
        sonidoFondoPrincipal.loop = false;
        sonidoFondoPrincipal.PlayOneShot(musicaFeliz);
        yield return new WaitForSeconds(2f);
        FadeToBlack();
        yield return new WaitForSeconds(2.5f);
        textoCreditos.SetActive(true);
    }

    public void escenaPrisionero()
    {
        gas.SetActive(false);
        StartCoroutine(Prisionero());
    }

    private IEnumerator Prisionero()
    {
        yield return new WaitForSeconds(7f);
        FadeToBlack();
        sonidoFondoPrincipal.Stop();
        sonidoFondoPrincipal.loop = false;
        yield return new WaitForSeconds(5f);
        NPCgas.SetActive(true);
        transformJugador.position = transformPosicionPrisionero.position;
        audioSourceHistoria.PlayOneShot(clipHistoria);
        prisionero.SetActive(false);
        manoJugador.SetActive(false);
        yield return new WaitForSeconds(2f);
        sonidoFondoPrincipal.PlayOneShot(musicaHorrorFinal);
        FadeFromBlack();
        yield return new WaitForSeconds(3f);
        FadeToBlack();
        yield return new WaitForSeconds(3f);
        FadeFromBlack();
        yield return new WaitForSeconds(6f);
        FadeToBlack();
        yield return new WaitForSeconds(3f);
        FadeFromBlack();
        yield return new WaitForSeconds(14f);
        animatorNpc.SetBool("Caminar", true);
        yield return new WaitForSeconds(6f);
        gas.SetActive(true);
        yield return new WaitForSeconds(3f);
        FadeToBlack();
        yield return new WaitForSeconds(2.5f);
        sonidoFondoPrincipal.Stop();
        sonidoFondoPrincipal.PlayOneShot(musicaCreditosFinal);
        textoCreditos.SetActive(true);
    }

    public void FadeToBlack()
    {
        if (currentFade != null) StopCoroutine(currentFade);
        currentFade = StartCoroutine(Fade(0f, 1f));
    }

    public void FadeFromBlack()
    {
        if (currentFade != null) StopCoroutine(currentFade);
        currentFade = StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;

            time += Time.deltaTime;
            yield return null;
        }

        // Asegura que llegue exactamente al valor final
        color.a = endAlpha;
        fadeImage.color = color;
        currentFade = null;
    }
}

