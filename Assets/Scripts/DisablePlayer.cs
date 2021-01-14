using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
    public void DisableAllComponents() {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour comp in comps) {
            comp.enabled = false;
        }
    }

    public void StopAllMovement() {
            Rigidbody playerRb = GetComponent<Rigidbody>();
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.maxAngularVelocity = 0f;
    }
}
