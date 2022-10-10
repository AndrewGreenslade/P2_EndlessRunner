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
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GenericGame"));
        game = gameGameObject.GetComponent<GameObject>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator JumpChecker()
    {
        GameObject enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Evil Square"));

        enemy.transform.position = new Vector3(0,0,0);

        yield return new WaitForSeconds(1);

        Assert.Greater(enemy.transform.position.y, 0);
    }

}
