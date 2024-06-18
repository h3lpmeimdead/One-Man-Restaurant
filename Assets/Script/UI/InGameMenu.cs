using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu, settingMenu;
    public Slider BGMSlider, SFXSlider;
    public bool isPaused;

    void Awake()
    {
        pauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void QuitGame()
    {
        Application.Quit();
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void Setting()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void OnClickBack()
    {
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void ToggleBGM()
    {
        AudioManager.instance.ToggleBGM();
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void ToggleSFX() 
    {
        AudioManager.instance.ToggleSFX();
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void BGMVolume()
    {
        AudioManager.instance.BGMVolume(BGMSlider.value);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(SFXSlider.value);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

}
