using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;
    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.lives <= 0)
        {
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
