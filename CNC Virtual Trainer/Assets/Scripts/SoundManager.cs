using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    private AudioSource audioSource;
    public AudioClip rotateSound;
    public AudioClip clickSound;
    public AudioClip breakSound;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRotateSound()
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(rotateSound);
    }

    public void PlayClickSound()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(clickSound);
    }
    public void PlayBreakSound()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(breakSound);
    }
}
