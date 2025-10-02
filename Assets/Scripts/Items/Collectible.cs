using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField, Min(1)] private int _value = 1;

    public event Action<Collectible> Collected;

    public int Value => _value;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
