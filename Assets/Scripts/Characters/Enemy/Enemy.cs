using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    private Patrol _patrol;

    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _patrol.enabled = true;
    }
}
