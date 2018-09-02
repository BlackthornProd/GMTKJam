using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour {

    public float offset = -90;
    public bool fireOne;
    private GameObject[] players;
    private Vector3 target;
    public GameObject projectile;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
      
    }

    void Update () {

        if (fireOne == true)
        {
            target = players[0].transform.position;
        }
        else
        {
            target = players[1].transform.position;
        }

        Vector3 difference = target - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    public void SpawnProjectile() {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
