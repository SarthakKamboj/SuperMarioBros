using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThroughBrick : MonoBehaviour
{
    // bool dieImmediately = false;
    public float timeToDieAfter = 0.4f;
    public float speedMultipler = 0.5f;
    GameObject audioManager;

    void Start() {
        audioManager = GameObject.Find("AudioManager");
        audioManager.GetComponent<SoundHandler>().Play("Coin");
        Destroy(gameObject, timeToDieAfter);
    }

    void Update() {
        Vector3 pos = transform.position;
        pos.y += speedMultipler;
        transform.position = pos;
    }
    

}
