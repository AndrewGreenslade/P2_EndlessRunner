using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DistanceScript : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI distanceText;
    public float distanceTraveled;

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += Time.deltaTime;
        int distanceTextDisplay = (int)distanceTraveled;
        distanceText.text = "Distance: " + distanceTextDisplay.ToString();
    }
}
