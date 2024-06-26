using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelChoosingMenu, mainMenu;
    public static int currentLevel, UnlockedLevels;
    public LevelObject[] levelObjects;
    public Sprite goldStarSprite;

    void Awake()
    {
        levelChoosingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    private void Start()
    {
        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
        for(int i = 0; i < levelObjects.Length; i++)
        {
            if(UnlockedLevels >= i)
            {
                levelObjects[i].levelButton.interactable = true;
                int stars = PlayerPrefs.GetInt("Stars" + i.ToString(), 0);
                for(int j = 0; j < stars; j++)
                {
                    levelObjects[i].stars[j].sprite = goldStarSprite;
                }
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100013459027548");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/ZykpQ8gmWY");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OpenItch()
    {
        Application.OpenURL("https://thanhdayma.itch.io/");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OpenKofi()
    {
        Application.OpenURL("https://ko-fi.com/thanhdayma");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OpenCredit()
    {
        CreditHandler.instance.OnShowCredit();
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OnClickBack()
    {
        levelChoosingMenu.SetActive(false);
        mainMenu.SetActive(true);
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OnClickPlay()
    {
        levelChoosingMenu.SetActive(true);
        mainMenu.SetActive(false);
        AudioManager.instance.PlaySFX("ButtonClick");
    }
    public void OnClickLevel(int levelNum)
    {
        currentLevel = levelNum;
        SceneManager.LoadScene("GameScene");
        AudioManager.instance.PlaySFX("ButtonClick");
    }
}
