using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToCastle : MonoBehaviour
{
    public Transform castleFrontTransform;
    public Transform castleTransform;
    public GameObject playerPrefab;
    Vector3 castleFrontPos;
    Vector3 castlePos;
    GameObject player;
    Vector3 forceDir;
    bool movingPlayerToCastleFront = false;
    bool movingPlayerToCastle = false;
    Rigidbody playerRb;
    float playerRadius;
    float playerCircumference;
    GameObject fakePlayer;
    Rigidbody fakePlayerRb;
    DisablePlayer fakePlayerDisable;

    void Start()
    {
        castleFrontPos = castleFrontTransform.position;        
        castlePos = castleTransform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        playerRadius = player.GetComponent<Collider>().bounds.extents.z;
        playerCircumference = 2 * playerRadius * Mathf.PI;
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        if (movingPlayerToCastleFront) {
            if (playerPos.x <= castleFrontPos.x) {
                fakePlayerRb.AddForce(forceDir * Time.deltaTime, ForceMode.VelocityChange);
                playerPos += forceDir * Time.deltaTime;
                player.transform.position = playerPos;
                player.transform.rotation = fakePlayer.transform.rotation;
            } else {
                movingPlayerToCastleFront = false;
                fakePlayerDisable.StopAllMovement();
                player.GetComponent<DisablePlayer>().StopAllMovement();
                movingPlayerToCastle = true;
            }
        } else if (movingPlayerToCastle) {
                fakePlayerRb.AddForce((castlePos - castleFrontPos) * Time.deltaTime, ForceMode.VelocityChange);
                playerPos += (castlePos - castleFrontPos).normalized * 2f * Time.deltaTime;
                player.transform.position = playerPos;
                player.transform.rotation = fakePlayer.transform.rotation;

                if (playerPos.x >= castlePos.x) {
                    movingPlayerToCastle = false;
                    Destroy(fakePlayer);
                }
        }

    }

    void GenerateFakePlayer() {
        fakePlayer = Instantiate(playerPrefab, player.transform.position, player.transform.rotation);
        fakePlayer.name = "fakePlayer";
        Collider fakePlayerCollider = fakePlayer.AddComponent<SphereCollider>();
        fakePlayerRb = fakePlayer.AddComponent<Rigidbody>();
        fakePlayerDisable = fakePlayer.AddComponent<DisablePlayer>();
        fakePlayer.GetComponent<MeshRenderer>().enabled = false;
    }

    public void MovePlayer(float time) {
        GenerateFakePlayer();
        Vector3 playerPos = player.transform.position;
        forceDir = (castleFrontPos - playerPos) / time;
        movingPlayerToCastleFront = true;
    }

}
