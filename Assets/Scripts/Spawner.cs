using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    public float decreaseSpawnTime;

    public GameObject[] monsters;
    public Transform[] spawnSpots;
    public PlayerSelect playerSelect;

    public int monsterLevel;
    public float startTimeBtwLV;
    private float timeBtwLV;
    public int maxLevel;

    bool stopSpawning;

    private void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
        timeBtwLV = startTimeBtwLV;
    }

    private void Update()
    {
        if (stopSpawning == false) {
            if (timeBtwLV <= 0)
            {
                if (startTimeBtwSpawn > 1.9f)
                {
                    startTimeBtwSpawn -= decreaseSpawnTime;
                }

                if (maxLevel > monsterLevel)
                {
                    monsterLevel++;
                }
                else
                {
                    playerSelect.canSpawnBoss = true;
                    stopSpawning = true;
                }

                timeBtwLV = startTimeBtwLV;
            }
            else
            {
                timeBtwLV -= Time.deltaTime;
            }


            if (timeBtwSpawn <= 0)
            {
                int randPos = Random.Range(0, spawnSpots.Length);
                int rand = Random.Range(0, monsterLevel);
                Instantiate(monsters[rand], spawnSpots[randPos].position, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        
    }

}
