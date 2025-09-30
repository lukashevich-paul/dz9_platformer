using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] PatrolTeritory _patrolTeritory;
    private Patrol _patrol;

    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _patrol.enabled = false;
    }

    private void OnEnable()
    {
        _patrolTeritory.PlayerCome += OnPatrolStart;
        _patrolTeritory.PlayerGone += OnPatrolStop;
    }

    private void OnDisable()
    {
        _patrolTeritory.PlayerCome -= OnPatrolStart;
        _patrolTeritory.PlayerGone -= OnPatrolStop;
    }

    private void OnPatrolStart()
    {
        _patrol.enabled = true;
    }

    private void OnPatrolStop()
    {
        _patrol.enabled = false;
    }
}
