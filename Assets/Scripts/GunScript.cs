using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject gun;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        //gun = GameObject.Find("Gun");
        gun.SetActive(true);     
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
