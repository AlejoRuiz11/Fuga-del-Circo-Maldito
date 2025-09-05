using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ControladorVolumen : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public TextMeshProUGUI textoPorcentajeVolumen; // Asigna este en el Inspector

    void Start()
    {
        float volumenGuardado = PlayerPrefs.GetFloat("volumenUsuario", 1f);
        slider.value = volumenGuardado;
        CambiarVolumen(volumenGuardado);

        slider.onValueChanged.AddListener(CambiarVolumen);
    }

    public void CambiarVolumen(float valor)
    {
        float volumenEnDb = Mathf.Log10(Mathf.Clamp(valor, 0.0001f, 1f)) * 20f;
        mixer.SetFloat("Volume", volumenEnDb);
        PlayerPrefs.SetFloat("volumenUsuario", valor);

        if (textoPorcentajeVolumen != null)
        {
            int porcentaje = Mathf.RoundToInt(valor * 100);
            textoPorcentajeVolumen.text = porcentaje + "%";
        }
    }
}