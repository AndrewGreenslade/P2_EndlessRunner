
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstacleBody;

    // private GameObject cloneExplosive;
    float enemySpeed = 2;
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
        if (gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);

        }
      //  transform.position = transform.position + -transform.right * Time.deltaTime * enemySpeed;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().loseLife();

            Destroy(gameObject);
        }
    }

}