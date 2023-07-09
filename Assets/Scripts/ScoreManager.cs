using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score;

    public int highScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("score", Score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void incrementScore()
    {
        Score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating(nameof(incrementScore), 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke(nameof(incrementScore));
        PlayerPrefs.SetInt("score", Score);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }

    }
}
