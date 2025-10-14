using UnityEngine;

public class ChaseZone : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            foreach (Enemy enemy in _enemies) {
                enemy.Chase(player);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Patrol();
            }
        }
    }
}
