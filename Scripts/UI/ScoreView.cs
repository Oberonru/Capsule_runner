using TMPro;
using UnityEngine;

namespace Enemies
{
    public class ScoreView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private int scoreChangedValue;
        private int _score;
        
        private void Start()
        {
            EventManager.EnemyDied += OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            _score += scoreChangedValue;
            print("Score " + _score);
            scoreText.text = "Score: "  + _score.ToString("0.0");
        }
    }
}