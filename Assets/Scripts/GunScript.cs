using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject gun;
    public GameObject bullet;
    private BulletScript bulletScript;
    // Start is called before the first frame update
    void Start()
    {
        //gun = GameObject.Find("Gun");
        gun.SetActive(true);
        bulletScript = GameObject.Find("Bullet").GetComponent<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void shootGun(bool t_isPlayerLookingLeft, Vector3 playerPosition)
    {
        Instantiate(bullet, playerPosition, Quaternion.identity);
    }
}
