using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public float DamageValue => _damage;

    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health _health))
        {
            if (gameObject.GetComponentInParent<Enemy>()) {
                if (collision.gameObject.TryGetComponent<Player>(out _))
                    _health.TakeDamage(DamageValue);
            } else {
                _health.TakeDamage(DamageValue);
            }
        }
    }
}
