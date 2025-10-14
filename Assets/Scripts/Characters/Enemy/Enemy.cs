using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Chaser))]
public class Enemy : MonoBehaviour
{
    private Patrol _patrol;
    private Chaser _chaser;

    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _chaser = GetComponent<Chaser>();

        Patrol();
    }

    public void Chase(Player player)
    {
        _patrol.enabled = false;

        _chaser.enabled = true;
        _chaser.Init(player);
    }

    public void Patrol()
    {
        _patrol.enabled = true;

        _chaser.enabled = false;
    }
}
