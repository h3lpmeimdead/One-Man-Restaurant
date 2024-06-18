using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] BGM, SFX;
    public AudioSource BGMsource, SFXsource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM("BackgroundMusic");
    }
    public void PlayBGM(string name)
    {
        Sound s = Array.Find(BGM, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            BGMsource.clip = s.clip;
            BGMsource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            SFXsource.PlayOneShot(s.clip);
        }
    }

    public void ToggleBGM()
    {
        BGMsource.mute = !BGMsource.mute;
    }
    public void ToggleSFX()
    {
        SFXsource.mute = !SFXsource.mute;
    }
    public void BGMVolume(float volume)
    {
        BGMsource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        SFXsource.volume = volume;
    }
}
