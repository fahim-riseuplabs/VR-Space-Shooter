using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Intro,
    Play,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static event Action OnPlayerScoreUpdated = delegate { };
    public UnityEvent OnStartActivated;
    public UnityEvent OnGameOver;
    public UnityEvent OnRestart;

    public static GameManager instance;

    public int _playerScore;
    public static GameState _currentGameState;
    public float _gameDuration;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentGameState = GameState.Intro;
    }

    public void PlayerScoreUpdate(int extraPoint)
    {
        if (_currentGameState.Equals(GameState.Play))
        {
            _playerScore += (100+extraPoint);

            OnPlayerScoreUpdated?.Invoke();
        }
        else
        {
            Debug.Log("Not in Play Mode");
        }
    }

    public void GameOver()
    {
        _currentGameState = GameState.GameOver;
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        _currentGameState = GameState.Play;
        OnStartActivated?.Invoke();
        Debug.Log("GameState.Play");
    }

    public void Restart()
    {
        _currentGameState = GameState.Play;
        _playerScore = 0;
        OnRestart?.Invoke();
    }
}
