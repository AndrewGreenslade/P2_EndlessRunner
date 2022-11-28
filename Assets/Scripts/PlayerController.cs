using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody2D rb;

    public int score = 0;
    private int jumpSpeed = 7;
    private float moveSpeed = 3;
    private bool isJumping = false;
    public int lives = 3;
    private string timesDied;
    private string distTraveled;
    private string highScore; 

   
    //https://docs.google.com/forms/d/e/1FAIpQLSfdbsO2vKysmX5H7sdABY5K6j155kXHvC_E2SpmcHrQ8XzJpA/viewform?usp=pp_url&entry.51372667=IDHERE&entry.1637826786=TIMESDIED&entry.1578808278=HIGHSCORE&entry.2039373689=DISTANCE



    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        timesDied = "10";
        distTraveled = "6969";
        highScore = "9999999";

    }


   
    // Update is called once per frame
    void Update()
    {
        //moveLeft();
        //moveRight();
        //jump();
        GameManager.instance.livesText.text = "Lives: " + lives.ToString();
        GameManager.instance.scoreText.text = "Score: " + score.ToString();


        //scoreText.text = "Score: " + score.ToString();
        if (lives <= 0)

        {
            Destroy(gameObject);
        }



      

    }

    public void moveLeft()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    public void moveRight()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    public void jump()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
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







}
