using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePool : MonoBehaviour
{
    public static AudioSourcePool Instance;
    public AudioSource AudioSourcePrefab;

    private List<AudioSource> audioSources;

    public void Awake()
    {
        Instance = this;
        audioSources = new List<AudioSource>();
    }

    public AudioSource GetSource()
    {
        foreach(AudioSource source in audioSources) if (!source.isPlaying) return source;
        AudioSource newSource = Instantiate<AudioSource>(AudioSourcePrefab, transform);
        audioSources.Add(newSource);
        return newSource;
    }
}
