using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static float timer;

    public GameObject panelPause;

    void Start()
    {
        timer = 1f;
    }

    void Update()
    {
        Time.timeScale = timer;
        if (panelPause.activeInHierarchy == false)
        {
            timer = 1f;
        }
        else if (panelPause.activeInHierarchy == true)
        {
            timer = 0f;
        }
    }

    public void PauseF()
    {
        switch (gameObject.name)
        {
            case "Continue":
                panelPause.SetActive(false);
                break;

            case "Menu":
                SceneManager.LoadScene("Menu");
                break;

            case "pause":
                panelPause.SetActive(true);
                break;
        }
    }
}
