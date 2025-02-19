// using UnityEngine;
//
// namespace Enemies
// {
//     public class EnemyPull : MonoBehaviour
//     {
//         [SerializeField] private Enemy _enemyPrefab; // Ссылка на префаб Enemy
//         [SerializeField] private int _pullSize = 10; // Размер пула
//
//         private Pull<Enemy> _enemyPull; // Экземпляр Pull<Enemy>
//
//         public static EnemyPull Instance { get; private set; } // Singleton pattern
//
//         private void Awake()
//         {
//             // Singleton pattern implementation
//             if (Instance != null && Instance != this)
//             {
//                 Destroy(this);
//             }
//             else
//             {
//                 Instance = this;
//             }
//
//             _enemyPull = new Pull<Enemy>(_enemyPrefab, _pullSize); // Создаем пул в Awake
//         }
//
//         // Метод для получения врага из пула (используйте его в других скриптах)
//         public Enemy GetEnemy()
//         {
//             return _enemyPull.Get();
//         }
//
//         // Метод для возвращения врага в пул (используйте его в других скриптах)
//         public void ReleaseEnemy(Enemy enemy)
//         {
//             _enemyPull.Release(enemy);
//         }
//
//         // Метод для создания Enemy
//         public Enemy CreateEnemy()
//         {
//             return _enemyPull.Create();
//         }
//     }
// }