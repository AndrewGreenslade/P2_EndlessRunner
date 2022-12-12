using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    void moveBullet()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            rb.velocity = new Vector3(10, 0, 0);

        }
        else
        {
            rb.velocity = new Vector3(-10, 0, 0);
        }
    }
}
