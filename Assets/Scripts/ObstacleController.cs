
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstacleBody;

    // private GameObject cloneExplosive;
    float enemySpeed = -3;
    private float timeLeft;
    private float velocityEnemy;
    private float playerPosx;

    Vector3 newRotation = new Vector3(75, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Screen.width);

        if (gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);

        }

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, 0);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("collision Enemy with bullet");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }





    }


    void OnCollisionEnter2D(Collision2D collision)
    {
   

    }

}