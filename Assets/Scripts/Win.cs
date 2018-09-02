using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    public Animator fadePanel;

    public void PlayGame()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play() {
        fadePanel.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }
}
