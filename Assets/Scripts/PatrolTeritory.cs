using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PatrolTeritory : MonoBehaviour
{
    public Action PlayerCome;
    public Action PlayerGone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerCome?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerGone?.Invoke();
    }
}
