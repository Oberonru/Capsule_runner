using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PointAttackEnemy : Enemy
    {
        private float _time;
        [SerializeField] private int damage = 1;

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
                    component.ApplyDamage(damage);
                }
            }
        }
    }
}