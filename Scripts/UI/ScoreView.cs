using TMPro;
using UnityEngine;

namespace Enemies
{
    public class ScoreView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private int _score;
        
        private void Start()
        {
            EventManager.CharacterDied += OnCharacterDied;
        }

        private void OnCharacterDied()
        {
            print("Score view enable");
            _score++;
            scoreText.text = "Score: "  + _score.ToString("0.0");
        }
    }
}