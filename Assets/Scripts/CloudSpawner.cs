using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject cloud;

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    public Transform[] spawnPoses;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, spawnPoses.Length);
            Instantiate(cloud, spawnPoses[rand].position, spawnPoses[rand].rotation);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
