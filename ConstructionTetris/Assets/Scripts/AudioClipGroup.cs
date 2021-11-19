using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioClipGroup")]
public class AudioClipGroup : ScriptableObject
{
    public float minVolume = 1;
    public float maxVolume = 1;
    public float minPitch = 1;
    public float maxPitch = 1;
    public float Cooldown = 0.1f;
    public List<AudioClip> AudioClips;

    private float timestamp;

    public void OnEnable()
    {
        timestamp = Time.time;
    }

    public void Play()
    {
        if (timestamp > Time.time) return;
        if (AudioClips.Count <= 0) return;

        timestamp = Time.time + Cooldown;

        AudioSource source = AudioSourcePool.Instance.GetSource();
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.clip = AudioClips[Random.Range(0, AudioClips.Count)];
        source.Play();
    }
}
