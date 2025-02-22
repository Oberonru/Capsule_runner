using UnityEngine;
using UnityEngine.Events;
using Enemies;

namespace DefaultNamespace
{
    public class Player : Character, IHeal
    {
        public MoveController MoveController => moveController;
        public UnityEvent OnApplyDamageEvent;
        [SerializeField] private MoveController moveController;
        [SerializeField] private HealthUI healthUI; 

        private void Start()
        {
            healthUI.InitUiHealth(MaxHealth);
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            healthUI.ShowHealth(CurrentHealth);
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
            OnApplyDamageEvent.Invoke();
            UpdateHealth();

            if (CurrentHealth < 1)
            {
                CurrentHealth = 0;
                Destroy(gameObject);
                EventManager.OnCharacterDied();
            }
        }

        public void ApplyHeal(int health)
        {
            CurrentHealth += health;
            if (CurrentHealth > MaxHealth)
            {
                MaxHealth = CurrentHealth;
            }
            
            UpdateHealth();
        }
    }
}