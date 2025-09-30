using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public event Action<Collectible> Collected;

    public void Collect()
    { 
        Collected?.Invoke(this);
    }
}
