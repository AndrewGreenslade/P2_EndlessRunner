using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DistanceScript : MonoBehaviour
{
    public PlayerScript player;
    public TextMeshProUGUI distanceText;
    public int distanceTraveled;
    public int distanceTimer;
    public int playerLives;
    private const int DISTANCE_INCREMENT_TIMER = 300;
    // Start is called before the first frame update
    void Start()
    {
        distanceTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTimer++;
        addDistance();
        distanceText.text = "Distance: " + distanceTraveled.ToString();
        playerLives = player.lives;
    }

    public void addDistance()
    {
        if (distanceTimer >= DISTANCE_INCREMENT_TIMER && playerLives > 0)
        {
            distanceTraveled++;
            distanceTimer = 0;
        }
    }

    public int getDistanceTraveled()
    {
        return distanceTraveled;
    }
}
