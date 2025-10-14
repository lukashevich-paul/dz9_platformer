using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public float DamageValue => _damage;

    private void Start()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health _health))
        {
            _health.TakeDamage(DamageValue);
        }
    }
}
