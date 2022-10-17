using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTests
{
    private GameObject game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<GameObject>();
        
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    //A Test behaves as an ordinary method
   [UnityTest]
    public IEnumerator JumpChecker()
    {

        GameObject enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Evil Snake"));

        enemy.transform.position = new Vector3(-5, 0, 0);

        enemy.GetComponent<JumpingEnemy>().StartCoroutine(enemy.GetComponent<JumpingEnemy>().Jumping());

        yield return new WaitForSeconds(5);

        Assert.Greater(enemy.transform.position.y, 0);
    }

    [UnityTest]
    public IEnumerator BoundingBoxChecker()
    {
        GameObject player = GameObject.Find("Player");

        player.transform.position = new Vector3(0, -5, 0);

        yield return new WaitForSeconds(0.1f);

        Assert.Less(player.GetComponent<PlayerScript>().lives, 3);
    }
}
