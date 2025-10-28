using UnityEngine;

[RequireComponent(typeof(Mover))]
public class BehaviorType : MonoBehaviour
{
    public const float DirectionPositive = 1f;
    public const float DirectionNegative = -1f;

    [SerializeField] protected Flipper Flipper;

    protected Mover Mover;

    protected void Awake()
    {
        Mover = GetComponent<Mover>();
    }
}
