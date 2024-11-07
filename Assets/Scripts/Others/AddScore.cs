using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private AudioManager audioManager;

    
    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Score>().addScore();
        audioManager.PlayVFX(audioManager.dieClip);
    }
}
