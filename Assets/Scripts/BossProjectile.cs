using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

    public float lifetime;
    public GameObject effect;
    public int damage;

    public float speed;
    private GameObject[] players;
    private Vector3 target;
    int rand;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Invoke("Death", lifetime);
        rand = Random.Range(0, 2);
      
    }

    private void Update()
    {
        if (rand == 0)
        {
            target = players[0].transform.position;
        }
        else
        {
            target = players[1].transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Death() {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerTopDown>().TakeDamage(damage);
            Death();
        }
    }
}
