using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnScoreGained += UpdateScore;

        UpdateScore();
    }

    private void OnDisable()
    {
        gameManager.OnScoreGained -= UpdateScore;
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {gameManager.Score}";
    }
}
