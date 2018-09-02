using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour {

    public bool isPlayerOne;
    public int health;
    public Slider healthBar;
    public int maxHealth;

    public int enemiesInGame;
    public bool canSpawnBoss;
    public GameObject boss;
    public GameObject slider;
    /* public Slider staminaOne;
     public Slider staminaTwo;
     public float staminaOneValue;
     public float staminaTwoValue;*/

    public Transform[] poses;
    public GameObject skull;
    public GameObject deathEffect;
    bool done;
    public GameObject restartOptions;
    public GameObject bossSlider;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (health > maxHealth) {
            health = maxHealth;
        }

        if (health <= 0 && done == false) {
            
            restartOptions.SetActive(true);
            Instantiate(skull, poses[0].position, Quaternion.identity);
            Instantiate(deathEffect, poses[0].position, Quaternion.identity);
            Instantiate(skull, poses[1].position, Quaternion.identity);
            Instantiate(deathEffect, poses[1].position, Quaternion.identity);
            Vector2 newTarget = new Vector2(10000, 10000);
            poses[0].position = newTarget;
            poses[1].position = newTarget;
            done = true;
        }

        if (canSpawnBoss == true && enemiesInGame <= 0) {
            bossSlider.SetActive(true);
            slider.SetActive(true);
            StartCoroutine(SpawnBoss());
            canSpawnBoss = false;
        }

        healthBar.value = health;

        /*staminaOne.value = staminaOneValue;
        staminaTwo.value = staminaTwoValue;

        if (isPlayerOne == true)
        {
            if (staminaTwoValue < 5) {
                staminaTwoValue += Time.deltaTime;
            }
            staminaOneValue -= Time.deltaTime;
           
        }
        else {

            if (staminaOneValue < 5)
            {
                staminaOneValue += Time.deltaTime;
            }
            staminaTwoValue -= Time.deltaTime;
            
        }

        if (staminaOneValue <= 0)
        {
            isPlayerOne = false;
        }
        else if(staminaTwoValue <= 0)
        {
            isPlayerOne = true;
        }*/

        if (Input.GetMouseButtonDown(1)) {
            if (isPlayerOne == true)
            {
                isPlayerOne = false;

            }
            else {
                isPlayerOne = true;
            }
        }
        
    }

    public void Sound() {
        source.Play();
    }


    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
