using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    private int index;
    public GameObject[] panels;
    public Animator fadePanel;
    bool done;

    private void Update()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);
            }
            else {
                panels[i].SetActive(false);
            }
        }

        if (Input.anyKeyDown) {
            if (index < 2)
            {
                index++;
            }
            else if(index >= 2 && done == false){
                index++;
                StartCoroutine(StartGame());
                done = true;
            }
            
        }
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(4f);
        
        fadePanel.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");    
    }
}
