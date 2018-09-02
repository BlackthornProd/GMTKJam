using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;

    public bool one;
    public PlayerSelect playerSelect;

    public GameObject projectile;
    private float timeBtwShot;
    public float startTimeBtwShot;
    public Transform projectileShot;
    private float recoveryTime = 1f;

    private void Start()
    {
       anim = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (recoveryTime > 0) {
            recoveryTime -= Time.deltaTime;
        }

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        if (playerSelect.isPlayerOne == one) {

            if (Input.GetKey(KeyCode.D) && timeBtwShot <= 0)
            {

                Instantiate(projectile, projectileShot.position, transform.rotation);
                timeBtwShot = startTimeBtwShot;
            }
            else {
                timeBtwShot -= Time.deltaTime;
            }
            


            

            if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetTrigger("takeOff");
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }

            if (isGrounded == true)
            {
                doubleJump = false;
                anim.SetBool("isJumping", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
            }


            if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;

            }

            if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.UpArrow))
            {
                isJumping = true;
                doubleJump = true;
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }

            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (moveInput != 0)
            {
                 anim.SetBool("isRunning", true);
            }
            else
            {
                 anim.SetBool("isRunning", false);
            }

            if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (moveInput > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector3.zero;
            }
            
            
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }
    }

    public void TakeDamage(int damage) {
        
        if (recoveryTime <= 0) {
            playerSelect.health -= damage;
            recoveryTime = 1f;
        }
        
    }
}
