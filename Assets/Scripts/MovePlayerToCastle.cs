using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToCastle : MonoBehaviour
{
    public Transform endTransform;
    public float movementMultipler = 2f;
    Vector3 endPos;
    GameObject player;
    Vector3 forceDir;
    bool movingPlayer = false;
    Rigidbody playerRb;

    void Start()
    {
        endPos = endTransform.position;        
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("moving player");
        if (movingPlayer) {
            Vector3 playerPos = player.transform.position;
            if (playerPos.x <= endPos.x) {
                playerRb.AddForce(Time.deltaTime * forceDir * movementMultipler);
            } else {
                movingPlayer = false;
            }
        }
    }

    public void MovePlayer() {
        movingPlayer = true;
        Vector3 playerPos = player.transform.position;
        forceDir = (endPos - playerPos).normalized;
    }

}
