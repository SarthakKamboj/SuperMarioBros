using UnityEngine;

public class FlowerHitPlayer : MonoBehaviour
{
    [SerializeField]
    private string mode;
    void OnCollisionEnter(Collision col) {
        if(col.collider.tag == "Player") {
            GameObject player = col.collider.gameObject;
            PlayerModes pm = player.GetComponent<PlayerModes>();
            pm.SetPlayerMode(mode);
            Destroy(gameObject);
        }
    }
}
