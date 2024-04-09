using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreScript : MonoBehaviour
{
    public event Action<int> ScoreChanged;
    public event Action ScoreHittedThousand;
    public static ScoreScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        CurrentScore = 1;
    }
    private int _currentScore;
    public Save save;
    public bool isPlaying = false;



    public UnityEvent onplay = new UnityEvent(); 
    public UnityEvent gameover = new UnityEvent();

    public int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;

            ScoreChanged?.Invoke(CurrentScore);
            bool a = value % 10 == 0;
            if (value % 10 == 0)
            {
                ScoreHittedThousand?.Invoke();
            }
        }
    }

    private void Update()
    {
       
    }
    IEnumerator Start()
    {

        while (true)
        {
            if (isPlaying)
            {
                IncrementScore();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void IncrementScore()
    {
        CurrentScore++;
    }
    public event Action OnThousand;
    public void StartGame()
    {
       
        onplay.Invoke();
        isPlaying = true;
        CurrentScore = 0;
    }
    public void GameOver()
    {
        if (save.highscore < CurrentScore)
        {
            save.highscore = CurrentScore;
        }
        isPlaying = false;
        gameover.Invoke();
    }
}
