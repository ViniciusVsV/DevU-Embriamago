using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System.Security;
using System;

public class Volume_Settings : MonoBehaviour
{

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("soundEffectVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSoundEffectVolume();
        }
    }

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);

    }
    public void SetSoundEffectVolume()
    {
        float volume = soundEffectSlider.value;
        myMixer.SetFloat("soundEffect", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("soundEffectVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVolume");

        SetMusicVolume();
        SetSoundEffectVolume();

    }
}
