using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour {

    private AudioSource source;
    public AudioClip[] clips;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        int rand = Random.Range(0, clips.Length);
        source.clip = clips[rand];
        source.Play();
    }
}
