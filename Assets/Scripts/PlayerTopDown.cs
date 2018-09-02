using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDown : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    public PlayerSelect playerSelect;
    public GameObject arrow;
    public bool one;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
}
