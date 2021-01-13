using UnityEngine;

public class BrickMaxHitsByPlayer : MonoBehaviour
{
    public int maxHits = 3;

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            maxHits -= 1;
        }

        if (maxHits == 0) {
            Destroy(gameObject);
        }
    }
}
