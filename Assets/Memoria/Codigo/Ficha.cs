using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    public int Id { get; set; }
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Animator m_Animator;

    private void OnMouseDown()
    {
        GameManager.instancia.ProcesarClickEnFicha(this);
    }

    public void MostrarFrente()
    {
        m_Animator.Play("FichaDeAtrasAlFrente");
    }

    public void MostrarReverso()
    {
        m_Animator.Play("FichaDeFrenteAAtras");
    }
    public void SetearImagen(Sprite sprite)
    {
        m_SpriteRenderer.sprite = sprite;
    }
}
 