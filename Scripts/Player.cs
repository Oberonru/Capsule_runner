using UnityEngine;
using Enemies;

namespace DefaultNamespace
{
    public class Player : Character, IHeal
    {
        [SerializeField] private HealthUI healthUI;
        [SerializeField] private BonusHealth bonusHealth;
        [SerializeField] private InnerHitEffect hitEffect;
        [SerializeField] private BlinkEffect blinkEffect;

        private void Start()
        {
            healthUI.InitUiHealth(CurrentHealth);
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            healthUI.ShowHealth(CurrentHealth);
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
            hitEffect.ShowInnerHitEffect();
            blinkEffect.Blinken();
            UpdateHealth();

            if (CurrentHealth < 1)
            {
                Destroy(gameObject);
                EventManager.OnCharacterDied();
            }
        }

        public void ApplyHeal(int health)
        {
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth += health;
                bonusHealth.HealthSound.Play();
                UpdateHealth();
            }
        }
    }
}