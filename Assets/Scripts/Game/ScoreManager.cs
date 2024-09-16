using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_score;
    [SerializeField] TextMeshProUGUI txt_highscore;

    int score = -1; // Since you get +1 point before passing any trap
    int highscore = 0;

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        txt_highscore.text = "High Score: " + highscore.ToString();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (score < 0)
        {
            int new_score = 0;
            txt_score.text = "Points: " + new_score.ToString();
        }
        else
        {
            txt_score.text = "Points: " + score.ToString();   
        }
    }

    private void UpdateHighScoreText()
    {
        txt_highscore.text = "High Score: " + highscore.ToString();
    }

    //Reset high score to 0 in PlayerPrefs
    private void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
    }

    //Called from Player script once it collides with a colorchanger obj
    public void CountScore()
    {
        score++;
        UpdateScoreText();

        // Update high score if necessary
        if (score > highscore)
        {
            highscore = score;
            UpdateHighScoreText();
            // Save the new high score
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.Save();
        }
    }
}
