using DefaultNamespace;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int attackDamage;
    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }
}