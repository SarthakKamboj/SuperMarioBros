using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SoundPool : MonoBehaviour
{


    [SerializeField]
    private Sound[] sounds;
    void Awake() {
        foreach(Sound sound in sounds) {
            for (int i = 0; i < sound.poolNumber; i++) {
                AudioSource audioSource = createAudioSource(sound);
                sound.sources.Add(audioSource);
            }
        }
    }

    private AudioSource createAudioSource(Sound sound) {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = sound.loop;
        audioSource.volume = sound.volume;
        audioSource.clip = sound.audioClip;
        audioSource.spatialBlend = sound.spatialBlend;
        return audioSource;
    }

    public void Play(string name) {
        Sound sound = Array.Find(sounds, s => s.audioClipName == name);
        List<AudioSource> sources = sound.sources;
        for (int i = 0; i < sources.Count; i++) {
            if (!sources[i].isPlaying) {
                sources[i].Play();
                return;
            }
        }
        // AudioSource audioSource = createAudioSource(sound);
        // Destroy();

        AudioSource.PlayClipAtPoint(sound.audioClip, new Vector3(0,0,0));
        // sources.Add();

    }
    
}
