using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    private GameObject[] players;
    public float speed;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, players[0].transform.position) < Vector2.Distance(transform.position, players[1].transform.position)) {
            transform.position = Vector2.MoveTowards(transform.position, players[0].transform.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, players[0].transform.position) > Vector2.Distance(transform.position, players[1].transform.position)) {
            transform.position = Vector2.MoveTowards(transform.position, players[1].transform.position, speed * Time.deltaTime);
        }
    }
}
