using UnityEngine;

public class ScrollCreditos : MonoBehaviour
{
    public float velocidad = 30f;
    private RectTransform rectTransform;
    private Vector2 inicioPos;
    private float alturaLimite;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inicioPos = rectTransform.anchoredPosition;

        // Calculamos el alto del texto y de la pantalla
        alturaLimite = rectTransform.sizeDelta.y + Screen.height;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            rectTransform.anchoredPosition += Vector2.up * velocidad * Time.deltaTime;
            if (rectTransform.anchoredPosition.y >= alturaLimite)
            {
                rectTransform.anchoredPosition = inicioPos;
            }
        }

        
    }
}