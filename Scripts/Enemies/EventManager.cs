using System;
using UnityEngine;

namespace Enemies
{
    public class EventManager
    {
        public static event Action EnemyDied;
        public static event Action<int> HealthChange;
        
        public static void OnEnemyDied()
        {
            EnemyDied?.Invoke();
        }

        public static void OnHealthChange(int value)
        {
            HealthChange?.Invoke(value);
        }
    }
}