using TMPro;
using UnityEngine;

namespace Enemies
{
    public class ScoreView: MonoBehaviour
    {
        //[SerializeField] private TMP_Text scoreText;
        private int _score;
        private void Start()
        {
            EventManager.EnemyDied += OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            //а если другое количество очкв, как изменить
            _score++;
            print("Score " + _score);
            //scoreText.text = "Score: "  + _score.ToString("0.0");
        }
    }
}