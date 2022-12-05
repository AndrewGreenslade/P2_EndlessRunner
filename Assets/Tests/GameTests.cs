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
    public IEnumerator DistanceAdditionChecker()
    {
        DistanceScript ds = new DistanceScript();
        int startDistance = ds.distanceTraveled;
        ds.distanceTimer = 300;
        ds.playerLives = 3;
        ds.addDistance();

        yield return new WaitForSeconds(1f);

        Assert.Greater(ds.distanceTraveled, startDistance);
    }

    [UnityTest]
    public IEnumerator DistanceAdditionWhileDeadChecker()
    {
        DistanceScript ds = new DistanceScript();
        ds.distanceTraveled = 0;
        ds.distanceTimer = 300;
        ds.playerLives = 0;
        ds.addDistance();

        yield return new WaitForSeconds(1f);

        Assert.Less(ds.distanceTraveled, 1);
    }
}
