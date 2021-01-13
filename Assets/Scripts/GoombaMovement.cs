using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public Vector3 initialDirection;
    public float speed;
    public LayerMask collisionLayerMask;
    

    void Update()
    {
        Vector3 pos = transform.position;
        pos += initialDirection * speed * Time.deltaTime;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision col) {
        if ((collisionLayerMask.value & (1 << col.gameObject.layer)) > 0) {
            initialDirection *= -1;
        }
    }
}
