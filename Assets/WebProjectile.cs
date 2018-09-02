using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebProjectile : MonoBehaviour {

    PlayerTopDown[] playerScript;
    Vector2 targetPosition;
    PlayerTopDown targetPlayer;

    public float speed;
    public int damage;


    public GameObject effect;

    private void Start()
    {
        // Invoke("Death", lifetime);
        playerScript = FindObjectsOfType<PlayerTopDown>();

        float distance = float.MaxValue;
        if (Vector2.Distance(transform.position, playerScript[0].transform.position) < distance)
        {
            distance = Vector2.Distance(transform.position, playerScript[0].transform.position);
            targetPosition = playerScript[0].transform.position;
            targetPlayer = playerScript[0];
        }

        if (Vector2.Distance(transform.position, playerScript[1].transform.position) < distance)
        {
            distance = Vector2.Distance(transform.position, playerScript[1].transform.position);
            targetPosition = playerScript[1].transform.position;
            targetPlayer = playerScript[1];
        }

    }


    private void Update()
    {

        if ((Vector2)transform.position == targetPosition)
        {

            Death();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            
            targetPlayer.TakeDamage(damage);
            other.GetComponent<PlayerTopDown>().Webify();
            Death();
        }

    }

    void Death()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
