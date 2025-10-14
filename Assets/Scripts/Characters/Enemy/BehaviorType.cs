using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Flipper))]
public class BehaviorType : MonoBehaviour
{
    public const float DirectionPositive = 1f;
    public const float DirectionNegative = -1f;

    protected Mover Mover;
    protected Flipper Flipper;

    protected void Awake()
    {
        Mover = GetComponent<Mover>();
        Flipper = GetComponent<Flipper>();
    }
}
