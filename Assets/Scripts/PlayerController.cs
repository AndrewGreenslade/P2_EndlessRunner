using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody2D rb;

    public float infectionSpeedIncrease = 2.0f;
    public int lives = 3;
    private float infectionVisibility = 0.0f;
    public float tempValueInfection = 0.0f;
    SpriteRenderer sprite;



    //https://docs.google.com/forms/d/e/1FAIpQLSfdbsO2vKysmX5H7sdABY5K6j155kXHvC_E2SpmcHrQ8XzJpA/viewform?usp=pp_url&entry.51372667=IDHERE&entry.1637826786=TIMESDIED&entry.1578808278=HIGHSCORE&entry.2039373689=DISTANCE



    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        InvokeRepeating("IncreaseInfection", infectionSpeedIncrease, infectionSpeedIncrease);
    }



    // Update is called once per frame
    void Update()
    {
        GameManager.instance.livesText.text = "Lives: " + lives.ToString();

        GameManager.instance.infectionText.text = "Infection: " + GameManager.instance.infection.ToString() + "%";


        //scoreText.text = "Score: " + score.ToString();
        if (lives <= 0)

        {
            Destroy(gameObject);
        }
        tempValueInfection = GameManager.instance.infection / 100;

        sprite.color = new Color(1, 1 - tempValueInfection, 1 - tempValueInfection, 1);


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //isJumping = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }

    public void resetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void loseLife()
    {
        lives--;
        GameManager.instance.livesText.text = "Lives: " + lives.ToString();
    }



    void IncreaseInfection()
    {
        if (GameManager.instance.infection <= 100)
        {
            GameManager.instance.infection++;
        }
    }



}