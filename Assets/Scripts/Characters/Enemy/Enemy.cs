using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Chaser))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ChaseZone _chaseZone;

    private Patroller _patroller;
    private Chaser _chaser;
    private Transform _previousTarget;

    private void Awake()
    {
        _patroller = GetComponent<Patroller>();
        _chaser = GetComponent<Chaser>();
    }

    private void Start()
    {
        Patrol();
    }

    private void Update()
    {
        if (_chaseZone.TargetTransform != null)
        {
            Chase(_chaseZone.TargetTransform);
        }
        else
        {
            Patrol();
        }
    }

    private void Chase(Transform transform)
    {
        if (_previousTarget != transform)
        {
            _previousTarget = transform;
            _patroller.enabled = false;

            _chaser.enabled = true;
            _chaser.Init(transform);
        }
    }

    private void Patrol()
    {
        _previousTarget = null;
        _patroller.enabled = true;

        _chaser.enabled = false;
    }
}
