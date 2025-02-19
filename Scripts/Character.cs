using DefaultNamespace;
using Enemies;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
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

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }
}