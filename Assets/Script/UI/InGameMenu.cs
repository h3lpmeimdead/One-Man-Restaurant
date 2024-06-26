using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu, settingMenu, onM, onS, offM, offS;
    public Slider BGMSlider, SFXSlider;
    //public bool isPaused;

    void Awake()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
        Time.timeScale = 0f;
        //isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //isPaused = false;
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
        Debug.Log("setting");
        settingMenu.SetActive(true);
        pauseMenu.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void OnClickBack()
    {
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
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
