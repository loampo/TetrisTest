using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        Debug.Log("Score reset");
    }
    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
