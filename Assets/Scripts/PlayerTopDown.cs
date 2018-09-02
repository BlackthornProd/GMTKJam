using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDown : MonoBehaviour {
    public float startSpeed;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    public PlayerSelect playerSelect;
    public GameObject arrow;
    public bool one;

    public GameObject webAffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startSpeed = speed;
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero && playerSelect.isPlayerOne == one)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        if(one == playerSelect.isPlayerOne) {
            arrow.SetActive(true);
        } else {
            arrow.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (one == playerSelect.isPlayerOne) {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
        
    }

    public void TakeDamage(int damage) {
        playerSelect.health -= damage;
    }

    public void Heal(int amount)
    {
        if (playerSelect.health + amount <= 10)
        {
            playerSelect.health += amount;
        } else {
            playerSelect.health = 10;
        }

    }

    public void Webify () {
        GameObject w = Instantiate(webAffect, transform.position, transform.rotation);
        w.GetComponent<Web>().playerWebed = this;
        speed = 0;
        transform.Find("weapon").GetComponent<Weapon>().startTimeBtwShot += 100000;
        transform.Find("weapon").GetComponent<Weapon>().timeBtwShot += 100000;

    }


    public void DeWebify(Web web)
    {
        Destroy(web.gameObject);
        speed = startSpeed;
        transform.Find("weapon").GetComponent<Weapon>().startTimeBtwShot -= 100000;
        transform.Find("weapon").GetComponent<Weapon>().timeBtwShot -= 100000;
    }


}
