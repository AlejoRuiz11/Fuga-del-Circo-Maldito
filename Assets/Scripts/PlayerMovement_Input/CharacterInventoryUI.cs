using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private GameObject mensajeInstruccion; // Texto: "Presiona Q para abrir/cerrar el inventario"
    private bool inventarioAbierto = false;

    void Start()
    {
        panelInventario.SetActive(false);
        mensajeInstruccion.SetActive(true);
        Invoke(nameof(DesactivarMensaje), 5f);
    }

    public void ToggleInventory()
    {
        inventarioAbierto = !inventarioAbierto;
        panelInventario.SetActive(inventarioAbierto);
    }

    void DesactivarMensaje()
    {
        mensajeInstruccion.SetActive(false);
    }
}