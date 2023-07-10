using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AudioPlayer : MonoBehaviour
{
    public static Scr_AudioPlayer Instance { get; private set; }
    
    private AudioSource audioSource;
    [Header("Sounds")]
    [SerializeField] private AudioClip cleanSound;
    [SerializeField] private AudioClip hammerSound;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;
    [SerializeField] private AudioClip activetrapSound;
    [SerializeField] private AudioClip hittrapSound;
    [SerializeField] private AudioClip freetrapSound;
    [SerializeField] private AudioClip freetrapfailSound;
    [SerializeField] private AudioClip freetrapsuccessSound;
    [SerializeField] private AudioClip putcoinsSound;
    [SerializeField] private AudioClip takecoinsSound;
    [SerializeField] private AudioClip dooropenSound;
    [SerializeField] private AudioClip doorcloseSound;
    [SerializeField] private AudioClip putobjectSound;
    [SerializeField] private AudioClip takeobjectSound;
    [SerializeField] private AudioClip activetrapdoorSound;
    [SerializeField] private AudioClip trapdoorTPSound;
    [SerializeField] private AudioClip step1Sound;
    [SerializeField] private AudioClip step2Sound;
    [SerializeField] private AudioClip buttonhoverSound;
    [SerializeField] private AudioClip buttonpressSound;
    [SerializeField] private AudioClip changeformSound;
    [SerializeField] private AudioClip timertickSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip grumpySound;
    [SerializeField] private AudioClip happySound;
    [SerializeField] private AudioClip starsSound;
    [SerializeField] private AudioClip transitionSound;


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

    public void PlaySuccessSound()
    {
        PlaySound(successSound,1);
    }

    public void PlayFailSound()
    {
        PlaySound(failSound, 1);
    }
    public void PlayTrapActiveSound()
    {
        PlaySound(activetrapSound, 1);
    }
    public void PlayTrapHitSound()
    {
        PlaySound(hittrapSound, 1);
    }
    public void PlayTrapFreeSound()
    {
        PlaySound(freetrapSound, 1);
    }
    public void PlayTrapFailedSound()
    {
        PlaySound(freetrapfailSound, 1);
    }
    public void PlayTrapSuccessSound()
    {
        PlaySound(freetrapsuccessSound, 1);
    }
    public void PlayPutCoinsSound()
    {
        PlaySound(putcoinsSound, 1);
    }
    public void PlayTakeCoinsSound()
    {
        PlaySound(takecoinsSound, 1);
    }
    public void PlayOpenSound()
    {
        PlaySound(dooropenSound, 1);
    }
    public void PlayCloseSound()
    {
        PlaySound(doorcloseSound, 1);
    }
    public void PlayPutSound()
    {
        PlaySound(putobjectSound, 1);
    }
    public void PlayTakeSound()
    {
        PlaySound(takeobjectSound, 1);
    }
    public void PlayTrapdoorOpenSound()
    {
        PlaySound(activetrapdoorSound, 1);
    }
    public void PlayTrapdoorTPSound()
    {
        PlaySound(trapdoorTPSound, 1);
    }
    public void PlayStep1Sound()
    {
        PlaySound(step1Sound, 1);
    }
    public void PlayStep2Sound()
    {
        PlaySound(step2Sound, 1);
    }
    public void PlayBTHoverSound()
    {
        PlaySound(buttonhoverSound, 1);
    }
    public void PlayBTPressSound()
    {
        PlaySound(buttonpressSound, 1);
    }
    public void PlayChangeFormSound()
    {
        PlaySound(changeformSound, 1);
    }
    public void PlayTimerTickSound()
    {
        PlaySound(timertickSound, 1);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound, 1);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound, 1);
    }
    public void PlayGrumpyHeroSound()
    {
        PlaySound(grumpySound, 1);
    }
    public void PlayHappyHeroSound()
    {
        PlaySound(happySound, 1);
    }
    public void PlayPoppingStarSound()
    {
        PlaySound(starsSound, 0.5f);
    }
    public void PlayTransitionSound()
    {
        PlaySound(transitionSound, 1);
    }


    private void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip,volume);
    }

}
