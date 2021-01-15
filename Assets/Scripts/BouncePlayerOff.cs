using UnityEngine;

public class BouncePlayerOff : MonoBehaviour
{
    public float bounceMultipler = 2f;
    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            Vector3 dir;
            if (col.collider.transform.position.z <= transform.position.z) {
                dir = new Vector3(0f,0f,-1f);
            } else {
                dir = new Vector3(0f,0f,1f);;
            }
            col.gameObject.GetComponent<Rigidbody>().AddForce(dir * bounceMultipler);
        }
    }
}
