using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _collisionCount = 0;

    public bool IsGround => _collisionCount > 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _collisionCount++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _collisionCount--;
        }
    }
}
