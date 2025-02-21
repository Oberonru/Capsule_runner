using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BlinkEffect))]
public class Enemy : Character
{
    public UnityEvent OnApplyDamage;
    [SerializeField] private int enemyDamage = 1;
    //private BlinkEffect blinkEffect;

    // private void OnValidate()
    // {
    //     // if (!blinkEffect)
    //     // {
    //     //     blinkEffect = GetComponent<BlinkEffect>();
    //     // }
    //     //
    //     // print("Blink effect" + blinkEffect);
    // }

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        //blinkEffect.Blinken();
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