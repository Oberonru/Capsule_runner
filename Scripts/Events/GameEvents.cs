using UnityEngine;
using Enemies;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private GameObject gameOverBg;

    private void Start()
    {
        gameOverBg.SetActive(false);
        EventManager.CharacterDied += OnGameOverImage;
    }

    private void OnGameOverImage()
    {
        gameOverBg.SetActive(true);
    }
}