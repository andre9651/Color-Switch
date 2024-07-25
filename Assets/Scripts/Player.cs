using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] ScoreManager score_manager;

    [SerializeField] float min_y_value;
    [SerializeField] float jump_force = 5f;
    [SerializeField] float gravaty_Scalor;

    [Header("Color Var")]
    private string current_color;
    [SerializeField] int number_of_colors = 4;
    [SerializeField] Color blue;
    [SerializeField] Color pink;
    [SerializeField] Color yellow;
    [SerializeField] Color green;    

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb.gravityScale = gravaty_Scalor;
    }

    private void Start()
    {
        SetRandomColor();
    }

    private void Update()
    {
        if (PlayerOffCamera())
        {
            GameOver();
        }
        SpacePressed();
    }

    private void SpacePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up* jump_force;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();           //Set a random color to the player
            Destroy(col.gameObject);    //Destroy the ColorChanger
            score_manager.CountScore();  //Add 1 to score
        }

        else if (col.tag != current_color)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");         //Display game over on logs
        gameObject.SetActive(false);    //Scene was taking some time to load so we dectivate the player untill scene resets
        SceneManager.LoadScene("Game"); //Reset the scene
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, number_of_colors);

        switch (index)
        {
            case 0:
                if (current_color != "Blue")
                {
                    current_color = "Blue";
                    sr.color = blue;
                }
                else
                    SetRandomColor();
                break;
            case 1:
                if (current_color != "Pink")
                {
                    current_color = "Pink";
                    sr.color = pink;
                }
                else
                    SetRandomColor();
                break;
            case 2:
                if (current_color != "Yellow")
                {
                    current_color = "Yellow";
                    sr.color = yellow;
                }
                else
                    SetRandomColor();
                break;
            case 3:
                if (current_color != "Green")
                {
                    current_color = "Green";
                    sr.color = green;
                }
                else
                    SetRandomColor();
                break;
        }
    }

    private bool PlayerOffCamera()
    {
        if (gameObject.transform.position.y < min_y_value)
            return true;
        else
            return false;
    }
}
