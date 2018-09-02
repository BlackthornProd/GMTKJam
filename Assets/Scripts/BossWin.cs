using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossWin : MonoBehaviour {

    private Animator fadePanel;

    private void Start()
    {
        fadePanel = GameObject.FindGameObjectWithTag("Panel").GetComponent<Animator>();
        StartCoroutine(Win());
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(3f);
        fadePanel.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Victory");
    }
}
