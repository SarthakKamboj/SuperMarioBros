using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    // [HideInInspector]
    // public AudioSource coinAudioSource;
    GameObject audioManager;
    void Start()
    {
        // coinAudioSource = GameObject.Find("AudioManager").transform.Find("CoinHit").gameObject.GetComponent<AudioSource>();
        audioManager = GameObject.Find("AudioManager");
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            // coinAudioSource.Play();
            audioManager.GetComponent<SoundHandler>().Play("Coin");
            Destroy(gameObject);
        }
    }
}
