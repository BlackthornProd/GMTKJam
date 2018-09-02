using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public int damage;

    private Animator camAnim;
    public GameObject deathEffect;
    private AddEnemy add;

    public GameObject[] pickups;
    public float percentageChange;


    private void Start()
    {
        add = GetComponent<AddEnemy>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (health <= 0) {
            Death();
        }
    }

    public void TakeDamage(int damage) {
        camAnim.SetTrigger("shake");
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerTopDown>().TakeDamage(damage);
            Death();
        }
    }

    void Death() {

        int r = Random.Range(0, 101);
        if (percentageChange > r)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], transform.position, transform.rotation);
        }
        add.Remove();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
