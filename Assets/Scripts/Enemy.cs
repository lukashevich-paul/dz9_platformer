using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] float _approvalDistance = 0.5f;

    private Mover _mover;
    private Flipper _flipper;
    private int _currentPoin = 0;

#if UNITY_EDITOR
    [ContextMenu("Fill waypoints by Route")]
    private void RefreshWaypoints()
    {
        _waypoints = new List<Transform>();

        for (int i = 0; i < _route.childCount; i++)
            _waypoints.Add(_route.GetChild(i));
    }
#endif

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        if (Math.Abs(_waypoints[_currentPoin].transform.position.x - transform.position.x) < _approvalDistance)
        {
            _currentPoin = ++_currentPoin % _waypoints.Count;
        }

        float direction = _waypoints[_currentPoin].transform.position.x - transform.position.x;
        direction /= Math.Abs(direction);

        _mover.Move(direction);
        _flipper.Flip(direction);
    }
}
