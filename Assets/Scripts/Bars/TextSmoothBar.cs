using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextSmoothBar : BarParent
{
    [SerializeField] private float _delay = 0.05f;

    private float _currentValue = 0f;
    private float _targetValue;
    private TMP_Text _text;
    private Coroutine _coroutine;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected override void Show()
    {
        _targetValue = Health.Value;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ShowSmoothly());
        }
    }

    private IEnumerator ShowSmoothly()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _currentValue = Mathf.Round(Mathf.MoveTowards(_currentValue, _targetValue, Health.MaxValue * _delay));
            _text.text = $"{_currentValue} / {Health.MaxValue}";

            yield return wait;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
