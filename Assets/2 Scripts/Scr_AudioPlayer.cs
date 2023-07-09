using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AudioPlayer : MonoBehaviour
{
    public static Scr_AudioPlayer Instance { get; private set; }
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip cleanSound;
    [SerializeField] private AudioClip hammerSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCleanSound()
    {
        PlaySound(cleanSound,1);
    }
    
    public void PlayHammerSound()
    {
        PlaySound(hammerSound,.5f);
    }


    private void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip,volume);
    }
}
