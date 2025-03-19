using TMPro;
using UnityEngine;

public class InteractionHover: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject GOtext;

    public void ShowText(string text)
    {
        _text.text = text + " (E)";
        GOtext.SetActive(true);
    }

    public void HideText()
    {
        GOtext.SetActive(false);
    }
}
