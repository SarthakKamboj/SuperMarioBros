using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class PlayerModes : MonoBehaviour
{
    [SerializeField]
    private PlayerModeMaterial[] mats;
    /*
    [SerializeField]
    private PlayerTexture[] playerTextures;
    */
    Material curMaterial;
    public Renderer rend;
    public float timeInCertainMode = 1f;
    private float timeLeft = 0f;
    // public Vector3[] colors;
    // VisualEffect visualEffect;
    // VFXEventAttribute eventAttribute;
    // private int x = 0;
    // static readonly ExposedProperty glowColor = "GlowColor";

    void Start()
    {
        curMaterial = mats[0].material;
        // eventAttribute = visualEffect.CreateVFXEventAttribute();
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
        // PlayerTexture texture = Array.Find(playerTextures, p => p.name == mode);
        curMaterial = curMode.material;        
        // Debug.Log(texture.texture.name);
        // material.SetTexture("Texture", texture.texture);
        // eventAttribute.SetVector3(glowColor, colors[x]);

        timeLeft = timeInCertainMode;
    }
}

[Serializable]
class PlayerModeMaterial {
    public string name;
    public Material material;
}

/*
[Serializable]
class PlayerTexture {
    public string name;
    public Texture texture;
}
*/