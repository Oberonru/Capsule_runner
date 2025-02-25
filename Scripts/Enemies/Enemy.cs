using UnityEngine.Events;

public class Enemy : Character
{
    public UnityEvent OnApplyDamage;

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        OnApplyDamage.Invoke();

        if (CurrentHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}