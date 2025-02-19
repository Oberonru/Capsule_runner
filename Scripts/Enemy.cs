public class Enemy : Character
{
    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);

        if (CurrentHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}