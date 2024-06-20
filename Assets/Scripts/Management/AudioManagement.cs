using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    [SerializeField] AudioSource Music_Source;
    [SerializeField] AudioSource SFX_Source;

    public AudioClip backgroundSound;
    public AudioClip playerShot;

    private void Start()
    {
        Music_Source.clip = backgroundSound;
        Music_Source.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX_Source.PlayOneShot(clip);
    }
}
