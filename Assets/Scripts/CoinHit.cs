using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    [HideInInspector]
    public AudioSource coinAudioSource;
    void Start()
    {
        coinAudioSource = GameObject.Find("AudioManager").transform.Find("CoinHit").gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            coinAudioSource.Play();
            Destroy(gameObject);
        }
    }
}
