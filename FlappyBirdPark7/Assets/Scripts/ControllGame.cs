using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllGame : MonoBehaviour
{

    public static ControllGame instance;
    public GameObject gameOverText;
    public bool GameOver = false;

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
    public void BirdDead()
    {
        gameOverText.SetActive(true);
        GameOver = true;
    }
}
