using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour {

    public Animator fadePanel;
    private string sceneN;

    public void Restart() {
        sceneN = "Game";
        StartCoroutine(RestartOption(sceneN));
    }
    public void Intro() {
        sceneN = "Start";
        StartCoroutine(RestartOption(sceneN));
    }

    IEnumerator RestartOption(string sceneName) {
        fadePanel.SetTrigger("fadeIn");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(sceneName);
             
    }
}
