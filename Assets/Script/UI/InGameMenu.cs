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
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void ToggleBGM()
    {
        AudioManager.instance.ToggleBGM();
    }
    public void ToggleSFX() 
    {
        AudioManager.instance.ToggleSFX();
    }
    public void BGMVolume()
    {
        AudioManager.instance.BGMVolume(BGMSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(SFXSlider.value);
    }

}
