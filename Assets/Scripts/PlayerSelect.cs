using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour {

    public bool isPlayerOne;
    public int health;
    public Slider healthBar;
  

   /* public Slider staminaOne;
    public Slider staminaTwo;
    public float staminaOneValue;
    public float staminaTwoValue;*/

        

    private void Update()
    {



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
}
