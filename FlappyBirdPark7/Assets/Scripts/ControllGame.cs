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
    public TextMeshProUGUI HighScoreText;
    public AudioClip ScoreSound;

    AudioSource audioSource;

    private int score = 0;

    public float scrollSpeed = -1.5f;
    // Start changed to awake. Awake called before Start.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        CheckHigScore();
    }
    public void BirdScored()
    {
        if (GameOver)
        {
            return;
        }


        score++;
        scoreText.text = "Score: " + score.ToString();
        PlaySound(ScoreSound);
    }
    private void CheckHigScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScore() ;
        }
    }

    public void BirdDead()
    {
        gameOverText.SetActive(true);
        GameOver = true;
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    void UpdateHighScore()
    {
        HighScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
