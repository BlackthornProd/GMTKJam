using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAura : MonoBehaviour {

    public float lifetime;
    public float neededDistance;
    public Sprite[] sprites;
    public float waitTimeBeforeHeal;
    public int healAmount;

    SpriteRenderer rend;
    GameObject[] players;

    public GameObject effect;
    private Animator anim;
    bool both;

    void Start () {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(Die());
    }

    private void Update()
    {
         
        if ((Vector2.Distance(transform.position, players[0].transform.position) < neededDistance) || (Vector2.Distance(transform.position, players[1].transform.position) < neededDistance))
        {
            rend.sprite = sprites[1];
            if((Vector2.Distance(transform.position, players[0].transform.position) < neededDistance) && (Vector2.Distance(transform.position, players[1].transform.position) < neededDistance))
            {
              
                rend.sprite = sprites[2];
                if (waitTimeBeforeHeal <= 0) {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    players[0].GetComponent<PlayerTopDown>().Heal(healAmount);
                    Destroy(gameObject);
                } else {
                    waitTimeBeforeHeal -= Time.deltaTime;
                }
            }
        } else {
            rend.sprite = sprites[0];
        }

  


    }

    IEnumerator Die() {
     
            yield return new WaitForSeconds(lifetime);
            anim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(1.25f);
            Destroy(gameObject);
        
       
    }

}
