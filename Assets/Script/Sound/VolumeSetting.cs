using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Net;
using Unity.VisualScripting.Dependencies.Sqlite;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject pauseMenu, settingMenu, onM, onS, offM, offS;

    private void Start()
    {
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }

    public void LoadSFXVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }

    public void ToggleOnBGM()
    {
        AudioManager.instance.ToggleBGM();
        offM.SetActive(true);
        onM.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void ToggleOffBGM()
    {
        AudioManager.instance.ToggleBGM();
        offM.SetActive(false);
        onM.SetActive(true);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void ToggleOnSFX()
    {
        AudioManager.instance.ToggleSFX();
        offS.SetActive(true);
        onS.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void ToggleOffSFX()
    {
        AudioManager.instance.ToggleSFX();
        offS.SetActive(false);
        onS.SetActive(true);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void Setting()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void OnClickBack()
    {
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
    }
}
