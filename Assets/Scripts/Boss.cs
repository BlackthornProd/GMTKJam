using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    private Slider slider;
    public BossFire[] fires;

    public float startTimeBtwShot;
    private float timeBtwShot;

    public GameObject startEffect;
    public GameObject effect;
    public GameObject loadWin;

    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        Instantiate(startEffect, transform.position, Quaternion.identity);
    }

    private void Update()
    {

        if (health <= 0) {
            Instantiate(loadWin, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        slider.value = health;

        if (timeBtwShot <= 0)
        {
           
            fires[1].SpawnProjectile();
            timeBtwShot = startTimeBtwShot;
        }
        else {
            timeBtwShot -= Time.deltaTime;
        }
    }


    public void TakeDamage(int damage) {
        health -= damage;
        fires[0].SpawnProjectile();
  
    }
}
