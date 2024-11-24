using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public float musicVolume = 0.25f;
    public float sfxVolume = 0.5f;
    public static SoundManager Instance { get; private set; }

    public AudioSource sfxSource; // Для звуковых эффектов
    public AudioSource musicSource; // Для фоновой музыки

    // Примеры звуковых эффектов
    public AudioClip[] coinSounds;
    public AudioClip scoreSound;
    public AudioClip failSound;
    public AudioClip clickSound;
    public AudioClip keySound;

    // Пример фоновой музыки
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void PlayCollectCoinSound()
    {
        sfxSource.PlayOneShot(coinSounds[Random.Range(0, coinSounds.Length)]);
    }

    public void PlayCollectKeySound()
    {
        sfxSource.PlayOneShot(keySound);
    }

    public void PlayBounceSound(AudioClip bounceSound)
    {
        sfxSource.PlayOneShot(bounceSound);
    }
    
    public void PlayFailSound()
    {
        sfxSource.PlayOneShot(failSound);
    }
    
    public void PlayScoreSound()
    {
        sfxSource.PlayOneShot(scoreSound);
    }

    public void PlayClickSound()
    {
        sfxSource.PlayOneShot(clickSound);
    }

    public void TurnOnMusic()
    {
        musicSource.volume = musicVolume;
        
    }
    public void TurnOffMusic()
    {
        musicSource.volume = 0;
    }
    
    public void TurnOnSfx()
    {
        sfxSource.volume = sfxVolume;
       
    }
    public void TurnOffSfx()
    {
        sfxSource.volume = 0;
    }
}