using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public int damage;
    public GameObject fireEffect;
    public float lifetime;

    private void Start()
    {
        Invoke("Death", lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Death();
        } else if (other.CompareTag("Player")) {
            other.GetComponent<PlayerTopDown>().TakeDamage(damage);
            Death();
        }
    }

    void Death() {
        Instantiate(fireEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
