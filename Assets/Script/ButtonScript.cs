using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool isPaused;
    [SerializeField] private UIScript uiscript;

    private void Start()
    {
        //uiscript = GameObject.FindGameObjectWithTag("Credit").GetComponent<UIScript>();
    }
    // Start is called before the first frame update
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

    //public void OpenCredit()
    //{
    //    uiscript.creditui.SetActive(true);
    //}
    
    //public void CloseButton()
    //{
    //    uiscript.creditui.SetActive(false);
    //}
}
