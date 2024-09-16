using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI high_score;  // TextMeshProUGUI component to update in the UI
    private string high_score_txt = "High Score";
    
    private void Update()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        high_score_txt = "High Score: " + highScore.ToString();  // Convert int to string with a label
        high_score.text = high_score_txt;  // Update the TextMeshProUGUI text property
    }
}
