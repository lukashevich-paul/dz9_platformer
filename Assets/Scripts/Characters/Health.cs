using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public const float PartOfMaxValue = 2f;

    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private float _value = 100f;

    public event Action Changed;
    public event Action Died;

    public float MaxValue => _maxValue;
    public float Value => _value;

    public void TakeDamage(float damage)
    {
        _value -= damage;

        Changed?.Invoke();

        if (_value <= 0)
            Died?.Invoke();
    }

    public void TakeCure()
    {
        _value += MaxValue / PartOfMaxValue;

        if (_value > MaxValue)
            _value = MaxValue;

        Changed?.Invoke();
    }
}
