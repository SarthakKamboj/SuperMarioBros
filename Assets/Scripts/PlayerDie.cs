using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Vector3 upForce = new Vector3(0f,20f,0f);
    public AudioSource hitPlayerAs;
    GameObject audioManager;

    void Start() {
        audioManager = GameObject.Find("AudioManager");
    }
    public void Die() {
        audioManager.GetComponent<SoundHandler>().Play("Player Die");
        StagnateMovement();
        DisableAllComponents();
        Destroy(gameObject, 5f);
    }

    void StagnateMovement() {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(upForce,ForceMode.VelocityChange);
        GetComponent<Collider>().isTrigger = true;
        rb.velocity = Vector3.up * rb.velocity.y;
    }

    private void DisableAllComponents() {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour comp in comps) {
            comp.enabled = false;
        }
    }
}
