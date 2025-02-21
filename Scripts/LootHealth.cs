using DefaultNamespace;
using UnityEngine;

public class LootHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private AudioSource healthSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var component))
        {
                component.ApplyHeal(health);

                healthSound.pitch = Random.Range(0.8f, 1.2f);
                healthSound.Play();

                Destroy(gameObject);
        }
    }
}