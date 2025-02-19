using System;
using UnityEngine;
using DefaultNamespace;

public class BonusHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private AudioSource healthSound;
    public AudioSource HealthSound => healthSound;

    private void Start()
    {
        healthSound = GetComponent<AudioSource>();
    }

    public void Init(int value)
    {
        this.health = value;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var component))
        {
            if (component.CurrentHealth != component.MaxHealth)
            {
                component.ApplyHeal(health);
                Destroy(gameObject);
            }
        }
    }
}