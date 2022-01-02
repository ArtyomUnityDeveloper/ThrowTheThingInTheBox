using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private ScoreScript scriptForScore;
    public ParticleSystem explosionParticle;
    public AudioClip hitSound;
    private AudioSource boxAudio;

    public int scoreForObject = 50;

    private void Start()
    {
        scriptForScore = FindObjectOfType<ScoreScript>();
        boxAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scriptForScore.UpdateScore(scoreForObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        boxAudio.PlayOneShot(hitSound, 1.0f);
    }
}
