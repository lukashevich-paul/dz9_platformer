using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x += direction * _speed * Time.fixedDeltaTime;
        _rigidbody.velocity = velocity;
    }
}
