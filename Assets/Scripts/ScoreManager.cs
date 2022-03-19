using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HighScore";

    public Text ScoreUI;
    public Text HighScoreUI;
    public Canvas rootCanvas;

    private int score = 0;

    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;        

        DisplayHighScore();
    }

    public void AddScore(int n)
    {
        score += n;
    }

    public void ZeroScore()
    {
        var highScorePref = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        
        if(score > highScorePref)
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);

        score = 0;
    }

    public void DisplayScore()
    {
        ScoreUI.text = $"Score: {score}";
    }

    public void DisplayHighScore()
    {
        var highScorePref = PlayerPrefs.GetInt(HIGH_SCORE_KEY);

        HighScoreUI.text = $"High Score: {highScorePref}";

    }
}
