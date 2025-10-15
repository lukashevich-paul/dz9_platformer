using UnityEngine;

public class ChaseZone : MonoBehaviour
{
    private Transform _targetTransform;

    public Transform TargetTransform => _targetTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _targetTransform = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _targetTransform = null;
        }
    }
}
