using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSmoothBar : BarParent
{
    [SerializeField] private float _delay = 0.05f;

    private float _targetValue;
    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void Show()
    {
        _targetValue = Health.Value / Health.MaxValue;

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
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _delay);

            yield return wait;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
