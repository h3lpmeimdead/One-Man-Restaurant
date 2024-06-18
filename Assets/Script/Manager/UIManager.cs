using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Timer timer;
    public List<GameObject> ui;
    [SerializeField] GameObject zeroStar;
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStars;
    [SerializeField] GameObject threeStars;
    [SerializeField] GameObject menuShowcase;
    [SerializeField] GameObject menuShowcaseInterface;

    private void Start()
    {
        menuShowcase.SetActive(true);
        menuShowcaseInterface.SetActive(false);
    }

    public void CheckForTimeRunsOut()
    {
        if(timer.remainingTime == 0 /*&& goal check 0 star*/)
        {
            zeroStar.SetActive(true);
            oneStar.SetActive(false);
            twoStars.SetActive(false);
            threeStars.SetActive(false);
            SetActiveUI(false);
            //AudioManager.instance.PlaySFX("ButtonClick");
        }
        if (timer.remainingTime == 0 /*&& goal check 1 star*/)
        {
            zeroStar.SetActive(false);
            oneStar.SetActive(true);
            twoStars.SetActive(false);
            threeStars.SetActive(false);
            SetActiveUI(false);
        }
        if (timer.remainingTime == 0 /*&& goal check 2 star*/)
        {
            zeroStar.SetActive(false);
            oneStar.SetActive(false);
            twoStars.SetActive(true);
            threeStars.SetActive(false);
            SetActiveUI(false);
        }
        if (timer.remainingTime == 0 /*&& goal check 3 star*/)
        {
            zeroStar.SetActive(false);
            oneStar.SetActive(false);
            twoStars.SetActive(false);
            threeStars.SetActive(true);
            SetActiveUI(false);
        }
        if(timer.remainingTime > 0)
        {
            zeroStar.SetActive(false);
            oneStar.SetActive(false);
            twoStars.SetActive(false);
            threeStars.SetActive(false);
            SetActiveUI(true);
        }
    }

    public void SetActiveUI(bool isActive)
    {
        foreach (GameObject obj in ui)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }

    public void OpenMenuShowcase()
    {
        menuShowcase.SetActive(false);
        menuShowcaseInterface.SetActive(true);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void CloseMenuShowcase()
    {
        menuShowcase.SetActive(true);
        menuShowcaseInterface.SetActive(false);
        //AudioManager.instance.PlaySFX("ButtonClick");
    }
}
