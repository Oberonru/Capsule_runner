using DefaultNamespace;
using UnityEngine;
using TMPro;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private TMP_Text healthUI;
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
            healthUI.text = _currentHealth.ToString();
        }

        public void ApplyDamage(int damage)
        {
            _currentHealth -= damage;
            healthUI.text = _currentHealth.ToString();

            if (_currentHealth < 1)
            {
                Destroy(gameObject);
                EventManager.OnEnemyDied();
            }
        }

        public void ChangeIntValue(int value)
        {
            _currentHealth += value;
        }
    }
}