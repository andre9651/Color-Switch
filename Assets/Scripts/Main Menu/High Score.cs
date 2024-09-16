using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI high_score_txt;  // TextMeshProUGUI instead of TextMeshPro

    private void Update()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        high_score_txt.text += highScore.ToString();  // Convert int to string
    }
}
