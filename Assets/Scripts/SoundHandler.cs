using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField]
    private List<Sound> sounds;
    void Start()
    {
        foreach (Sound sound in sounds) {
            for (int i = 0; i < sound.numInstances; i++) {
                sound.sources.Add(CreateAudioSource(sound));
            }
        }
    }

    public void Play(string soundName) {
        Sound sound = Array.Find<Sound>(sounds.ToArray(), s => s.name == soundName);
        if (sound == null) {
            return;
        }
        int i = 0;
        while (i < sound.sources.Count) {
            AudioSource aS = sound.sources[i];
            if (!aS.isPlaying) {
                aS.Play();
                return;
            }
            i += 1;
        }
        AudioSource newAudioSource = CreateAudioSource(sound);
        newAudioSource.Play();
        Destroy(newAudioSource,newAudioSource.clip.length);
    }


    AudioSource CreateAudioSource(Sound sound) {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.loop = sound.loop;
        source.mute = sound.mute;
        source.playOnAwake = sound.playOnAwake;
        source.volume = sound.volume;
        return source;
    }

}

[System.Serializable]
class Sound {
    public string name;
    public int numInstances = 1;
    public bool loop = false;
    public bool mute = false;
    public bool playOnAwake = false;
    [Range(0,1)]
    public float volume = 0.5f;
    public AudioClip clip;

    [HideInInspector]
    public List<AudioSource> sources;
}