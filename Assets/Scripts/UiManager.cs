using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI HighScore1;
    public TextMeshProUGUI HighScore2;
    public GameObject TapText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        HighScore1.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {

    }

    public void GameStart()
    {
        TapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        HighScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
