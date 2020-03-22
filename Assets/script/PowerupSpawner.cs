using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject speedPowerUpPrefab;

    private float _spawnTime;

    private void Start()
    {
        NewSpawnTime();
        StartCoroutine(SpawnPowerUp());

    }
    
    private GameObject pickRandomPowerUp()
    {
        float powerUp = UnityEngine.Random.Range(0, 3);

        //for now it's -1 because i only have one powerUp
        if (powerUp != -1)
        {
        }
        return speedPowerUpPrefab;
    }
    private void NewSpawnTime()
    {
        _spawnTime = UnityEngine.Random.Range(20f, 50f);
    }
    
    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(_spawnTime);
        GameObject powerUp = pickRandomPowerUp();
        Instantiate(powerUp, transform.position, Quaternion.identity);
        GameObject powerUpInGame = GameObject.Find(powerUp.name + "(Clone)");

        while (true)
        {
            if (powerUpInGame == null)
            {
                NewSpawnTime();
                yield return new WaitForSeconds(_spawnTime);
                powerUp = pickRandomPowerUp();
                Instantiate(powerUp, transform.position, Quaternion.identity);
                powerUpInGame = GameObject.Find(powerUp.name + "(Clone)");
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
        }
    }
}
