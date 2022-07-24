using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<Sound> sounds = new List<Sound>();
    private void Awake()
    {
        Instance = this;
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.vol;
            sound.source.pitch = sound.pitch;
        }
    }
    public void PlaySound(string soundName)
    {
        Sound sound = sounds.Find(x => x.name == soundName);
        sound.source.Play();
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float vol;
    [Range(0.1f, 3f)] public float pitch;
    [HideInInspector] public AudioSource source;
}
