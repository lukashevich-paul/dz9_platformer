using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        Vector3 playerPosition = _player.position;
        playerPosition.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, _speed * Time.deltaTime);
    }
}
