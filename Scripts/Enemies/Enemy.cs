using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    public UnityEvent OnApplyDamage;
    [SerializeField] private int enemyDamage = 1;

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        OnApplyDamage.Invoke();

        if (CurrentHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.TryGetComponent<Player>(out var component))
        {
            if (_time > 1)
            {
                _time = 0;
                component.ApplyDamage(enemyDamage);
            }
        }
    }
}