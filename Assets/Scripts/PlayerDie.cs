using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Vector3 upForce = new Vector3(0f,20f,0f);
    public SceneHandler sceneHandler;
    GameObject audioManager;

    void Start() {
        audioManager = GameObject.Find("AudioManager");
    }
    

    public void Die() {
        SoundHandler soundHandler = audioManager.GetComponent<SoundHandler>();
        soundHandler.Play("Player Die");
        BounceUp();
        GetComponent<DisablePlayer>().DisableAllComponents();
        sceneHandler.RestartLevel(soundHandler.GetClip("Player Die").length);
        // Destroy(gameObject, 5f);

    }

    void BounceUp() {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(upForce,ForceMode.VelocityChange);
        GetComponent<Collider>().isTrigger = true;
        rb.velocity = Vector3.up * rb.velocity.y;
    }

}
