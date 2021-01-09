using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
class Sound {
    public string audioClipName;
    public AudioClip audioClip;
    [Range(0f,1f)]
    public float volume = 0.5f;
    [Range(1f,5f)]
    public float poolNumber = 3f;
    [Range(0f,1f)]
    public float spatialBlend;

    [HideInInspector]
    public List<AudioSource> sources;
    public bool loop = false;
}