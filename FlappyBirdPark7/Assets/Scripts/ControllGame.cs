using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllGame : MonoBehaviour
{

    public static ControllGame instance;
    public GameObject gameOverText;
    public bool GameOver = false;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    public float scrollSpeed = -1.5f;
    // Start changed to awake. Awake called before Start.
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == true && Input.GetMouseButtonDown (0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        if (GameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdDead()
    {
        gameOverText.SetActive(true);
        GameOver = true;
    }
}
