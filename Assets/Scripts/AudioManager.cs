using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance; 
    public static AudioManager Instance 
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager:: Instance is null");
            }
            return _instance;
        }
    }

    [SerializeField] private AudioSource _voiceOverAudio;
    [SerializeField] private AudioSource _music;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOverAudio.clip = clipToPlay;
        _voiceOverAudio.Play();
    }
    public void StopMusic()
    {
        _music.Stop();
    }
}
