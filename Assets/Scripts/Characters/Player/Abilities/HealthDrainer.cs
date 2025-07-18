using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemySearcher))]
public class HealthDrainer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _zoneRenderer;
    [SerializeField] private Health _health;

    [SerializeField] private float _drainDuration = 6f;
    [SerializeField] private float _cooldownDuration = 4f;
    [SerializeField] private int _drainDamage = 100;
    [SerializeField] private int _drainHealing = 100;
    [SerializeField] private float _damageInterval = 0.5f;

    private EnemySearcher _enemySearcher;
    private bool _isDraining = false;
    private bool _isCooldown = false;
    private float _lastDamageTime;

    public Enemy Target { get; private set; }

    private void Awake()
    {        
        _zoneRenderer = GetComponent<SpriteRenderer>();
        _enemySearcher = GetComponent<EnemySearcher>();
    }

    private void Start()
    {
        _zoneRenderer.enabled = _isDraining;
    }

    public void Drain()
    {
        if (_isCooldown == false)
            StartCoroutine(DrainHealthCoroutine());
    }

    private IEnumerator DrainHealthCoroutine()
    {
        _isDraining = true;
        _zoneRenderer.enabled = _isDraining;

        float drainTime = 6f;
        float timer = 0.0f;

        while (timer < drainTime)
        {
            Target = _enemySearcher.GetClosestEnemy();
            timer += Time.deltaTime;

            if (Target != null && Time.time >= _lastDamageTime + _damageInterval)
            {
                if (Target.TryGetComponent<Health>(out Health enemyHealth))
                {
                    enemyHealth.TakeDamage(_drainDamage);
                    _health.Restore(_drainHealing);
                    _lastDamageTime = Time.time;
                }
            }

            yield return null;
        }

        _isDraining = false;
        _zoneRenderer.enabled = _isDraining;
        Target = null;

        float cooldown = 4f;
        WaitForSeconds waitCooldown = new WaitForSeconds(cooldown);

        _isCooldown = true;
        yield return waitCooldown;
        _isCooldown = false;
    }
}