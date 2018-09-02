using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float speed;

    public float distance;
    public LayerMask whatIsObstacle;
    bool movingRight;

    public bool isDownPatrol;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance, whatIsObstacle);
        RaycastHit2D hitInfoTwo = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsObstacle);

        if (isDownPatrol == false)
        {
            if (hitInfo.collider != null)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = false;
                    //transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    movingRight = true;
                    //transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else {
            if (hitInfoTwo.collider == null)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = false;
                    //transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    movingRight = true;
                    //transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        
    }
}
