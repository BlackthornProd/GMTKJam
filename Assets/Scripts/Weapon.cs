using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;
    public PlayerSelect playerSelect;
    public bool one;

    public GameObject projectile;
    public Transform shotPos;
    public float startTimeBtwShot;
    private float timeBtwShot;

	void Update () {
        if (playerSelect.isPlayerOne == one) {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShot <= 0)
            {
                if (Input.GetMouseButton(0)) {
                    Instantiate(projectile, shotPos.position, transform.rotation);
                    timeBtwShot = startTimeBtwShot;
                }
            }
            else {
                timeBtwShot -= Time.deltaTime;
            }
        }
   
	}
}
