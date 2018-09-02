using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaBomba : MonoBehaviour
{

    public float lifetime;
    public float neededDistance;
    public Sprite[] sprites;
    public float waitTimeBeforeBomb;
    public float timeEffect;
    public float amount;

    SpriteRenderer rend;
    GameObject[] players;

    public GameObject effect;
    private Animator anim;
    public GameObject sound;

    bool done;

    void Start()
    {

        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(Die());
    }

    private void Update()
    {

       /* if ((Vector2.Distance(transform.position, players[0].transform.position) < neededDistance) || (Vector2.Distance(transform.position, players[1].transform.position) < neededDistance))
        {
            rend.sprite = sprites[1];
            if ((Vector2.Distance(transform.position, players[0].transform.position) < neededDistance) && (Vector2.Distance(transform.position, players[1].transform.position) < neededDistance))
            {

                rend.sprite = sprites[2];
                if (waitTimeBeforeBomb <= 0 && !done)
                {
                    done = true;
                    Instantiate(effect, transform.position, Quaternion.identity);


                    TimeDown();
                }
                else
                {
                    waitTimeBeforeBomb -= Time.deltaTime;
                }
            }
        }
        else
        {
            rend.sprite = sprites[0];
        }*/




    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Instantiate(sound, transform.position, Quaternion.identity);
            TimeDown();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    IEnumerator Die()
    {

        yield return new WaitForSeconds(lifetime);
        anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1.25f);
        Destroy(gameObject);


    }


    void TimeDown () {
        Weapon[] weapon = FindObjectsOfType<Weapon>();
        weapon[0].startTimeBtwShot = weapon[0].startTimeBtwShot - amount;
        weapon[1].startTimeBtwShot = weapon[1].startTimeBtwShot - amount;
        weapon[0].IncreaseTime(amount);
        weapon[1].IncreaseTime(amount);
        Destroy(gameObject);

    }

}