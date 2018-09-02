using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private float speed;
    public float minSpeed;
    public float maxSpeed;
    public float lifetime;
    private SpriteRenderer rend;
    public Sprite[] cloudSprites;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, cloudSprites.Length);
        rend.sprite = cloudSprites[rand];
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
