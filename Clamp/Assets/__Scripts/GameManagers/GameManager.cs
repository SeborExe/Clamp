using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    public event Action OnScoreGained;

    public int Score { get; private set; }

    [SerializeField] private Player player;

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddScore(int score)
    {
        Score += score;
        OnScoreGained?.Invoke();
    }
}
