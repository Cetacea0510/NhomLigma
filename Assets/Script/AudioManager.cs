using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
    private AudioSource source;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.loop = false;
        source.PlayOneShot(_sound);
    }
    
    public void PlayLoopSound(AudioClip _sound)
    {
        source.loop = true;
        source.PlayOneShot(_sound);
    }
}
