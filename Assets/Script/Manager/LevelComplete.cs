using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //MainMenu mainMenu;
    public void NextLevel(int starsAquired)
    {
        if(MainMenu.currentLevel == MainMenu.UnlockedLevels)
        {
            MainMenu.UnlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", MainMenu.UnlockedLevels);
        }
        if(starsAquired > PlayerPrefs.GetInt("Stars" + MainMenu.currentLevel.ToString(), 0))
        {
            PlayerPrefs.SetInt("Stars" + MainMenu.currentLevel.ToString(), starsAquired);
        }
        SceneManager.LoadScene("MainMenu");
        //mainMenu.levelChoosingMenu.SetActive(true);
        //mainMenu.mainMenu.SetActive(false);
    }
}
