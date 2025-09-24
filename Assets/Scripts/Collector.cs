using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collectible _collectible))
        {
            Destroy(_collectible.gameObject);
        }
    }
}
