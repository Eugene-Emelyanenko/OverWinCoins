using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private Image sfxImage;
        [SerializeField] private Image musicImage;

        [SerializeField] private Sprite[] sfxSprites;
        [SerializeField] private Sprite[] musicSprites;
        
        private bool sfxOn = true;
        private bool musicOn = true;
        
        private int sfx = 1;
        private int music = 1;

        private void Start()
        {
            music = PlayerPrefs.GetInt("Music", 1);
            sfx = PlayerPrefs.GetInt("SFX", 1);

            SetBoolVariables();
            SaveSettings();
        }

        public void Music()
        {
            musicOn = !musicOn;
            SaveSettings();
        }

        public void Sfx()
        {
            sfxOn = !sfxOn;
            SaveSettings();
        }
        
        private void SetBoolVariables()
        {
            sfxOn = (sfx == 1);
            musicOn = (music == 1);
        }
        
        private void SaveSettings()
        {
            sfx = sfxOn ? 1 : 0;
            music = musicOn ? 1 : 0;

            sfxImage.sprite = sfxOn ? sfxSprites[1] : sfxSprites[0];
            musicImage.sprite = musicOn ? musicSprites[1] : musicSprites[0];
            
            if(music == 0)
                SoundManager.Instance.TurnOffMusic();
            else
                SoundManager.Instance.TurnOnMusic();

            if (sfx == 0)
                SoundManager.Instance.TurnOffSfx();
            else
                SoundManager.Instance.TurnOnSfx();
            
            PlayerPrefs.SetInt("SFX", sfx);
            PlayerPrefs.SetInt("Music", music);
            
            PlayerPrefs.Save();
        }

    }
