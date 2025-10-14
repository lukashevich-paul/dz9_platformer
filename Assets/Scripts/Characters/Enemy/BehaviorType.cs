using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Flipper))]
public class BehaviorType : MonoBehaviour
{
    public const float DirectionPositive = 1f;
    public const float DirectionNegative = -1f;

    protected Mover _mover;
    protected Flipper _flipper;

    protected void Awake()
    {
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
    }
}
