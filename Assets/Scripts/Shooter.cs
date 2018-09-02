using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float stopDistance;
    public GameObject enemyProjectile;
    public float speed;
    public float timeBetweenAttacks;
    public Transform shotPoint;

    float attackTime;
    GameObject[] player;
    Animator anim;
    Transform nearest;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        float distance = float.MaxValue;
        if (Vector2.Distance(transform.position, player[0].transform.position) < distance)
        {
            distance = Vector2.Distance(transform.position, player[0].transform.position);
            nearest = player[0].transform;
        }

        if (Vector2.Distance(transform.position, player[1].transform.position) < distance)
        {
            distance = Vector2.Distance(transform.position, player[1].transform.position);
            nearest = player[1].transform;
        }

        if (Vector2.Distance(transform.position, nearest.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearest.position, speed * Time.deltaTime);
        } 

        if (Time.time >= attackTime)
        {
            attackTime = Time.time + timeBetweenAttacks;
            anim.SetTrigger("shoot");
        }
    }


    public void Shoot () {

        if (player != null)
        {

            Vector2 direction = nearest.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(enemyProjectile, shotPoint.position, shotPoint.rotation);

        }

    }

}
