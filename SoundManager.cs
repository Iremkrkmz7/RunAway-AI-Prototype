using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{get; private set;}

    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip levelCompleteSound;
    public AudioClip winSound;
    private AudioSource _audioSource;

    void Awake()
    {
        if(Instance != null) {Destroy(gameObject); return;}
        Instance = this;
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null) // ← ekle
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayCoin()        => _audioSource.PlayOneShot(coinSound);
    public void PlayDeath()       => _audioSource.PlayOneShot(deathSound);
    public void PlayLevelComplete() => _audioSource.PlayOneShot(levelCompleteSound);
    public void PlayWin()         => _audioSource.PlayOneShot(winSound);
}
