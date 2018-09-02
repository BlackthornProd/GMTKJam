using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private PlayerSelect player;
    private Animator anim;
    public int healthBoost;
    public GameObject effect;

    public float lifeTime;
    public GameObject sound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerSelect>();
        StartCoroutine(Death());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Instantiate(sound, transform.position, Quaternion.identity);
            player.health += healthBoost;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Death() {
        yield return new WaitForSeconds(lifeTime);
        anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);   
    }
}
