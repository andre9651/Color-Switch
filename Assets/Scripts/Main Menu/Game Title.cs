using TMPro;
using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI game_title;  // TextMeshProUGUI component to update in the UI
    private string game_title_txt = "Color: ";    // Prefix for the game title text
    private string game_title_txt2 = "Switch";    // The word to change color
    private Coroutine colorChangeCoroutine;       // To hold the coroutine reference

    private void Start()
    {
        // Start the coroutine to change the color every 2 seconds
        colorChangeCoroutine = StartCoroutine(ChangeColorEvery2Seconds());
    }

    // Coroutine to change the color of the word "Switch" every 2 seconds
    private IEnumerator ChangeColorEvery2Seconds()
    {
        while (true)
        {
            // Generate softer random colors by clamping the random values between 0.2 and 0.8
            float r = Random.Range(0f, 0.5f);
            float g = Random.Range(0f, 0.5f);
            float b = Random.Range(0f, 0.5f);
            Color randomColor = new Color(r, g, b);
            
            // Apply the color to the word "Switch" using rich text formatting
            game_title.text = game_title_txt + $"<color=#{ColorUtility.ToHtmlStringRGB(randomColor)}>{game_title_txt2}</color>";

            // Wait for 2 seconds before changing the color again
            yield return new WaitForSeconds(2f);
        }
    }
}
