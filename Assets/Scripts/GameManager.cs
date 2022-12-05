using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int highScore = 0;

    public GameObject restartButton;
    public GameObject menuExitButton;
    public GameObject nextLevelButton;
    public PlayerController player;
    public TextMeshProUGUI hScoreText;
    public TextMeshProUGUI infectionText;
    public TextMeshProUGUI nextLevelText;
    public Canvas bgCanvas;
    private float targetTime = 0.0f;
    public float infection = 0.0f;

    public static GameManager instance;
    public DistanceScript distanceScrpt;
    private string deviceID;


    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfdbsO2vKysmX5H7sdABY5K6j155kXHvC_E2SpmcHrQ8XzJpA/viewform?usp=pp_url&entry.51372667=";


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

        instance.distanceScrpt = FindObjectOfType<DistanceScript>();
        instance.bgCanvas.worldCamera = Camera.main;
        instance.player = FindObjectOfType<PlayerController>();
        instance.restartButton.SetActive(false);
        if (SceneManager.GetActiveScene().name == "EndlessMode")
        {
            instance.menuExitButton.SetActive(false);
        }
        else {
            instance.nextLevelButton.SetActive(false);
        }
    }

    IEnumerator Post()//, string email, string phone)
    {

        WWWForm form = new WWWForm();
        //form.AddField("entry.51372667", name);
        byte[] rawData = form.data;
        string url = BASE_URL;

        // Post a request to an URL with our custom headers
        WWW www = new WWW(url, rawData);
        yield return www;
    }

    public void Send()
    {
        StartCoroutine(Post());
    }

    // Update is called once per frame
    void Update()
    {
        if (instance != null)
        {
            if (instance.highScore <= instance.distanceScrpt.distanceTraveled)
            {
                instance.hScoreText.text = "High Score: " + instance.highScore;
                instance.highScore = (int)instance.distanceScrpt.distanceTraveled;
            }

            if (instance.infection >= 100)
            {
                instance.restartButton.SetActive(true);
                instance.menuExitButton.SetActive(true);
            }

            if(instance.infection < 0)
            {
                instance.infection = 0;
            }


            deviceID = uniqueID();
            BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfdbsO2vKysmX5H7sdABY5K6j155kXHvC_E2SpmcHrQ8XzJpA/viewform?usp=pp_url&entry.51372667=" + deviceID + "&entry.1637826786=" + "1" + "&entry.1578808278=" + instance.highScore + " &entry.2039373689=" + distanceScrpt.distanceTraveled;

            targetTime -= Time.deltaTime;

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
            {

                instance.nextLevelText.text = "Level2";

                if (distanceScrpt.distanceTraveled >= 50)
                {
                    instance.nextLevelButton.SetActive(true);
                }
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                instance.nextLevelText.text = "Level3";

                if (distanceScrpt.distanceTraveled >= 50)
                {
                    instance.nextLevelButton.SetActive(true);

                }
            }
           

            if (Input.GetKey(KeyCode.L))
            {
                if (targetTime <= 0.0f)
                {
                    Application.OpenURL(BASE_URL);
                    Debug.Log("deviceID" + deviceID);

                    Send();
                    targetTime = 5.0f;
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
            {
                Destroy(this.gameObject);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public void RestartGame()
    {
        instance.hScoreText.text = "High Score: " + instance.highScore;
        instance.infection = 0;
        instance.distanceScrpt.distanceTraveled = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level2()
    {
        
        if(instance.infection >= 20)
        {
            instance.infection -= 20;
        }
        else
        {
            instance.infection = 0;
        }
        SceneManager.LoadScene("Level2");
        distanceScrpt.distanceTraveled = 0;
        FindObjectOfType<PlayerController>().m_cameraMain = Camera.main;
    }

    public void Level3()
    {
        if (instance.infection >= 20)
        {
            instance.infection -= 20;
        }
        else
        {
            instance.infection = 0;
        }
        SceneManager.LoadScene("Level3");
        distanceScrpt.distanceTraveled = 0;
        FindObjectOfType<PlayerController>().m_cameraMain = Camera.main;
    }


    string uniqueID()
    {

        int z1 = UnityEngine.Random.Range(0, 1000000);
        int z2 = UnityEngine.Random.Range(0, 1000000);
        string uid = z1 + "/" + z2;
        return uid;
    }
}
