using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public Text countKills;
    public Text countBoss;
    public Text bestTime;

    void Update()
    {
        countKills.text = PlayerPrefs.GetInt("countKills").ToString();
        countBoss.text = PlayerPrefs.GetInt("countBoss").ToString();
        bestTime.text = PlayerPrefs.GetInt("bestTime").ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Settings");
    }
}
