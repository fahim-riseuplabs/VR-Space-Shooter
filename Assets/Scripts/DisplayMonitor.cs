using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayMonitor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Image _timerImage;
    private float _timerImageFillAmount=1f;

    private void OnEnable()
    {
        GameManager.OnPlayerScoreUpdated += OnDisplayScore;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerScoreUpdated -= OnDisplayScore;
    }

    private void Update()
    {
        if (GameState.Play.Equals(GameManager._currentGameState))
        {
            _timerImage.fillAmount = (_timerImageFillAmount - (Time.deltaTime / GameManager.instance._gameDuration));
            _timerImageFillAmount = _timerImage.fillAmount;

            if (_timerImageFillAmount <= 0f)
            {
                GameManager.instance.GameOver();
                _timerImageFillAmount = 1f;
            }
        }
    }

    private void OnDisplayScore()
    {
        _scoreText.text = $"{GameManager.instance._playerScore}";
    }
}
