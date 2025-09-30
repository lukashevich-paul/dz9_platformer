using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public readonly float MinChance = 0f;
    public readonly float MaxChance = 1f;

    [SerializeField] List<Transform> _spawnpoints;
    [SerializeField] List<Collectible> _prefabs;
    [SerializeField, Range(0f, 1f)] float _chance = 0.6f;

#if UNITY_EDITOR
    [ContextMenu("Fill spawnpoints by Route")]
    private void RefreshWaypoints()
    {
        _spawnpoints = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
            _spawnpoints.Add(transform.GetChild(i));
    }
#endif

    private void Start()
    {
        foreach (Transform point in _spawnpoints)
        {
            if (Random.Range(MinChance, MaxChance) <= _chance)
            {
                Collectible prefab = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], point);

                prefab.Collected += OnCollected;
            }
        }
    }

    private void OnCollected(Collectible collectible)
    {
        Destroy(collectible.gameObject);
    }
}
