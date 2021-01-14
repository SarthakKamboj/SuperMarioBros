using UnityEngine;

public class PlayerFinished : MonoBehaviour
{
    GameObject audioManager;

    void Start() {
        audioManager = GameObject.Find("AudioManager");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audioManager.GetComponent<SoundHandler>().Play("Level Over");
            DisablePlayer dp = other.gameObject.GetComponent<DisablePlayer>();
            dp.DisableAllComponents();
            dp.StopAllMovement();
            GameObject.FindGameObjectWithTag("Flag").GetComponent<BringFlagDown>().FlagDown();
        }
    }
    
}
