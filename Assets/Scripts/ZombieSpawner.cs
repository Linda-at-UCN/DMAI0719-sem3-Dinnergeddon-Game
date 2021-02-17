using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieSpawner : NetworkBehaviour
{




    public GameObject enemyPrefab;

    //maximum spawn range left
    public float leftRange;
    //maximum spawn range right
    public float rightRange;
    public float minimumWait;
    public float maximumWait;

    void Start()
    {

        SpawnZombie();

    }

    void SpawnZombie()
    {

        var spawnPosition = new Vector2(
            Random.Range(-leftRange, rightRange),
             gameObject.transform.position.y);

        //since it's 2D we don't nede rotation
        var spawnRotation = Quaternion.Euler(
            0.0f,
            0.0f,
            0.0f);

        var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
        NetworkServer.Spawn(enemy);
        float spawnTime = Random.Range(minimumWait, maximumWait);
        Debug.Log("Spawn in : " + spawnTime);
        Invoke("SpawnZombie", spawnTime);

        if (minimumWait >= 0.25f)
        {
            minimumWait = minimumWait - 0.1f;
        }

        if (maximumWait >= 0.5f)
        {
            maximumWait = maximumWait - 0.1f;
        }
    }

}

