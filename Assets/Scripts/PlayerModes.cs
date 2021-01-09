using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModes : MonoBehaviour
{
    [SerializeField]
    private PlayerModeMaterial[] mats;
    private Material curMaterial;
    public Renderer rend;
    public float timeInCertainMode = 1f;
    private float timeLeft = 0f;

    void Start()
    {
        curMaterial = mats[0].material;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0f) {
            timeLeft -= Time.deltaTime;
            rend.sharedMaterial = curMaterial;
        } else {
            rend.sharedMaterial = mats[0].material;
        }
    }

    public void SetPlayerMode(string mode) {
        PlayerModeMaterial curMode = Array.Find(mats,m => m.name == mode);
        curMaterial = curMode.material;        
        timeLeft = timeInCertainMode;
    }
}

[Serializable]
class PlayerModeMaterial {
    public string name;
    public Material material;
}
