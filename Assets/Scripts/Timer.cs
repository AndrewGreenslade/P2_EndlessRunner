using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private float timeLeft;
    [SerializeField]
    private bool isTimerActive;
    // Start is called before the first frame update
    void Start()
    {
        isTimerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        TickingTime();
    }

    void TickingTime()
    {
        if (isTimerActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
