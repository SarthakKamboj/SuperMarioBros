using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitGoomba : MonoBehaviour
{
    Bounds goombaBounds;
    Vector3 goombaCenter, goombaExtents;
    public Vector3 hitForce = new Vector3(0f,10f,0f);
    void Start() {
        goombaBounds = GetComponent<Collider>().bounds;
        goombaCenter = goombaBounds.center;
        goombaExtents = goombaBounds.extents;
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {

            Vector3 colPoint = col.contacts[0].point;
            if (goombaExtents.y >= Mathf.Abs(goombaCenter.y - colPoint.y)) {
                if (goombaExtents.z >= Mathf.Abs(goombaCenter.z - colPoint.z)) {
                    if (goombaExtents.x >= Mathf.Abs(goombaCenter.x - colPoint.x)) {
                        col.collider.gameObject.GetComponent<Rigidbody>().AddForce(hitForce,ForceMode.VelocityChange);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

}
