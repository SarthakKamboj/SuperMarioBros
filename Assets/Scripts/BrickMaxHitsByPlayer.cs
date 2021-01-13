using UnityEngine;

public class BrickMaxHitsByPlayer : MonoBehaviour
{
    public int minHits = 1;
    public int maxHits = 7;
    int hits;

    void Start() {
        hits = Random.Range(minHits, maxHits);
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            hits -= 1;
        }

        if (hits == 0) {
            Destroy(gameObject);
        }
    }
}
