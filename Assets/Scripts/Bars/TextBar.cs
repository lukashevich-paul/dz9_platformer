using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextBar : BarParent
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected override void Show()
    {
        _text.text = $"{Health.Value} / {Health.MaxValue}";
    }
}
