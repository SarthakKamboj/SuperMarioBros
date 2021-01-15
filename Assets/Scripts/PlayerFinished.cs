using Cinemachine;
using UnityEngine;

public class PlayerFinished : MonoBehaviour
{
    GameObject audioManager;
    public CinemachineFreeLook cinemachineCamera;
    public AudioClip levelOverAudioClip;

    void Start() {
        audioManager = GameObject.Find("AudioManager");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SoundHandler soundHandler = audioManager.GetComponent<SoundHandler>();
            soundHandler.Play("Level Over");
            DisablePlayer dp = other.gameObject.GetComponent<DisablePlayer>();
            dp.DisableAllComponents();
            dp.StopAllMovement();
            GameObject.FindGameObjectWithTag("Flag").GetComponent<BringFlagDown>().FlagDown();
            float timeTillEndAnimOver = soundHandler.GetClip("Level Over").length;
            cinemachineCamera.GetComponent<ZoomOutCamera>().ZoomOut(timeTillEndAnimOver);
            GameObject.FindGameObjectWithTag("Castle").GetComponent<MovePlayerToCastle>().MovePlayer(timeTillEndAnimOver);
        }
    }
    
}
