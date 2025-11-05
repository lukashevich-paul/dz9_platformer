using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Vampirism : MonoBehaviour
{
    public enum Statuses { Ready, Active, Charge };
    public int MaxEnemyHitColleders = 5;

    [SerializeField] private Health _health;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _scale = 40f;
    [SerializeField] private float _radius = 4f;
    [SerializeField] private float _damageValue = 1f;
    [SerializeField] private float _tickTime = 0.25f;
    [SerializeField, Range(0f, 1f)] private float _vampirePower = 1f;
    [SerializeField] private float _activeTimeSeconds = 6f;
    [SerializeField] private float _chargeTimeSeconds = 4f;

    private SpriteRenderer _spriteRenderer;
    private Statuses _currentStatus;
    private Coroutine _activeCoroutine;
    private WaitForSeconds _wait;

    public event Action StatusChange;

    public float ActiveSeconds { get; private set; }
    public float ChargeSeconds { get; private set; }
    public Statuses CurrentStatus
    {
        get => _currentStatus;
        private set
        {
            _currentStatus = value;
            StatusChange?.Invoke();
        }
    }

    private void Awake()
    {
        CurrentStatus = Statuses.Ready;
        transform.localScale = Vector3.one * _scale;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        enabled = false;
        _wait = new WaitForSeconds(_tickTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    public void Run()
    {
        if (_currentStatus == Statuses.Ready && _activeCoroutine == null)
        {
            _activeCoroutine = StartCoroutine(Work());
        }
    }

    private IEnumerator Work()
    {
        ActiveSeconds = _activeTimeSeconds;
        _spriteRenderer.enabled = true;
        CurrentStatus = Statuses.Active;

        while (ActiveSeconds > 0)
        {
            ActiveSeconds -= _tickTime;

            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.useLayerMask = true;
            contactFilter.SetLayerMask(_layerMask);

            Collider2D[] hitColliders = new Collider2D[MaxEnemyHitColleders];

            if (Physics2D.OverlapCircle(transform.position, _radius, contactFilter, hitColliders) > 0)
            {
                Collider2D neighborHitCollider = null;
                float magnitude = _scale;

                foreach (Collider2D hitCollider in hitColliders)
                {
                    if (hitCollider != null)
                    {
                        float hitMagnitude = (transform.position - hitCollider.transform.position).magnitude;

                        if (magnitude > hitMagnitude && hitCollider.gameObject.TryGetComponent<Enemy>(out _))
                        {
                            neighborHitCollider = hitCollider;
                        }
                    }
                }

                if (neighborHitCollider != null && neighborHitCollider.gameObject.TryGetComponent(out Health enemyHealth))
                {
                    if (enemyHealth.Value > 0)
                    {
                        enemyHealth.TakeDamage(_damageValue);
                        _health.TakeCure(_damageValue * _vampirePower);
                    }
                }
            }

            yield return _wait;
        }

        _activeCoroutine = StartCoroutine(Charge());
    }

    private IEnumerator Charge()
    {
        ChargeSeconds = 0;
        _spriteRenderer.enabled = false;
        CurrentStatus = Statuses.Charge;

        while (ChargeSeconds < _chargeTimeSeconds)
        {
            ChargeSeconds += _tickTime;
            yield return _wait;
        }

        CurrentStatus = Statuses.Ready;
        StopActiveCoroutine();
        gameObject.SetActive(false);
    }

    private void StopActiveCoroutine()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
            _activeCoroutine = null;
        }
    }
}
