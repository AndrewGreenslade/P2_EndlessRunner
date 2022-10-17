using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int highScore = 0;

    public GameObject restartButton;
    public PlayerScript player;
    public TextMeshProUGUI hScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public Canvas bgCanvas;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        instance.bgCanvas.worldCamera = Camera.main;
        instance.player = FindObjectOfType<PlayerScript>();
        instance.restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (instance != null)
        {
            if (instance.highScore <= instance.player.score)
            {
                instance.hScoreText.text = "High Score: " + instance.highScore;
                instance.highScore = instance.player.score;
            }

            if (player.lives <= 0)
            {
                instance.restartButton.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {

        instance.hScoreText.text = "High Score: " + instance.highScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
