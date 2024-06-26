using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime;
    SpawnCustomers spawnCustomers;
    Quest quest;

    private void Start()
    {
        quest = FindObjectOfType<Quest>();
        spawnCustomers = FindObjectOfType<SpawnCustomers>();
        remainingTime = spawnCustomers.totalTime;
    }
    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    public void CountDown()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0 && quest.currentQuest < 5)
        {
            remainingTime = 0;
            SceneManager.LoadScene("GameOver");
        }
        if (remainingTime <= 10)
        {
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
