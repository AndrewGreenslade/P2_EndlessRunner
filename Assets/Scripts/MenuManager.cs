using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoryMode()
    {
        SceneManager.LoadScene("Game");
        //FindObjectOfType<PlayerController>().m_cameraMain = Camera.main;
    }


    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
        //FindObjectOfType<PlayerController>().m_cameraMain = Camera.main;
    }
    public void Exit()
    {
        Application.Quit();  
    }
}
