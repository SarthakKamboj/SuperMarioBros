using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThroughBrick : MonoBehaviour
{
    // bool dieImmediately = false;
    public float timeToDieAfter = 2f;
    public float speedMultipler = 3f;

    public void Start() {
        // dieImmediately = true;
        AudioSource aS = gameObject.GetComponent<AudioSource>();
        aS.Play();
        Destroy(gameObject, aS.clip.length);
    }

    public void Update() {
        // if (dieImmediately) {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime*speedMultipler;
        transform.position = pos;
        // }
    }
    

}
