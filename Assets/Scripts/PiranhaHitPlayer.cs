using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaHitPlayer : MonoBehaviour
{
/*    public Transform topCenter;
    public Transform bottomCenter;
    public float radius = 1f;
    public float maxDistance = 0.1f;
    public LayerMask layerMask;
    public GameObject gameManager;

    void Start()
    {
                            
    }

    void Update()
    {
        GameObject player = gameManager.GetComponent<MainPlayer>().mainPlayer;
        Vector3 sweepDir = (player.transform.position - transform.position).normalized;
        if (Physics.CapsuleCast(topCenter.position, bottomCenter.position,radius,sweepDir,maxDistance,layerMask)) {
            Debug.Log("hit player");
        }
    }
    */

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            col.gameObject.GetComponent<PlayerDie>().Die();
        }
    }
}
