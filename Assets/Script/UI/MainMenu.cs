using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100013459027548");
    }

    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/ZykpQ8gmWY");
    }

    public void OpenItch()
    {
        Application.OpenURL("https://thanhdayma.itch.io/");
    }
    public void OpenKofi()
    {
        Application.OpenURL("https://ko-fi.com/thanhdayma");
    }

    public void OpenCredit()
    {
        CreditHandler.instance.OnShowCredit();
    }
}
