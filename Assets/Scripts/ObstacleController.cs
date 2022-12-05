
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

    [SerializeField]
    //private GameObject m_sporeParticle;
    //private ParticleSystem m_sporeParticle;
    private GameObject m_sporeParticle;

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
            GameManager.instance.infection = GameManager.instance.infection + 10;
            Instantiate(m_sporeParticle,transform.position, Quaternion.identity);
            //m_sporeParticle.transform.position = gameObject.transform.position;
            //m_sporeParticle.Emit(100);
            //m_sporeParticle.Play();
            //DestroyImmediate(m_sporeParticle);
            Destroy(gameObject);

        }
    }

}