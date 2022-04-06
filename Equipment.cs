using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Equipment : MonoBehaviour
{
    public GameObject _infoPanel;
    private int nal0 = 1;
    private int i;
    private int nal1;
    private int nal2;
    private int nal3;
    private int nal4;
    private int nal5;
    private int nal6;
    private int nal7;

    public List<GameObject> stats;
    public List<GameObject> guns_;
    public List<GameObject> select_;

    private void Start()
    {
        PlayerPrefs.SetInt("GunIndex", i);
        PlayerPrefs.Save();
        i = PlayerPrefs.GetInt("index");
        _infoPanel.SetActive(false);
        for (int j = 0; j < stats.Count; j++)
        {
            stats[j].SetActive(false);
        }
        for (int j = 0; j < select_.Count; j++)
        {
            select_[j].SetActive(false);
        }
        select_[i].SetActive(true);
        for (int j = 1; j < guns_.Count; j++)
        {
            guns_[j].SetActive(false);
        }
        nal1 = PlayerPrefs.GetInt("nal1");
        nal2 = PlayerPrefs.GetInt("nal2");
        nal3 = PlayerPrefs.GetInt("nal3");
        nal4 = PlayerPrefs.GetInt("nal4");
        nal5 = PlayerPrefs.GetInt("nal5");
        nal6 = PlayerPrefs.GetInt("nal6");
        nal7 = PlayerPrefs.GetInt("nal7");
        if (nal0 == 1)
        {
            guns_[0].SetActive(true);
        }
        if (nal1 == 1)
        {
            guns_[1].SetActive(true);
        }
        if (nal2 == 1)
        {
            guns_[2].SetActive(true);
        }
        if (nal3 == 1)
        {
            guns_[3].SetActive(true);
        }
        if (nal4 == 1)
        {
            guns_[4].SetActive(true);
        }
        if (nal5 == 1)
        {
            guns_[5].SetActive(true);
        }
        if (nal6 == 1)
        {
            guns_[6].SetActive(true);
        }
        if (nal7 == 1)
        {
            guns_[7].SetActive(true);
        }
    }

    private void Clean()
    {
        for(int j = 0; j < stats.Count; j++)
        {
            stats[j].SetActive(false);
        }
        for (int j = 0; j < stats.Count; j++)
        {
            select_[j].SetActive(false);
        }
    }

    public void Equip()
    {
        switch (gameObject.name)
        {
            case "guns_7":
                Clean();
                _infoPanel.SetActive(true);
                i = 7;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_6":
                Clean();
                _infoPanel.SetActive(true);
                i = 6;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_5":
                Clean();
                _infoPanel.SetActive(true);
                i = 5;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_4":
                Clean();
                _infoPanel.SetActive(true);
                i = 4;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_3":
                Clean();
                _infoPanel.SetActive(true);
                i = 3;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_2":
                Clean();
                _infoPanel.SetActive(true);
                i = 2;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_1":
                Clean();
                _infoPanel.SetActive(true);
                i = 1;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;

            case "guns_0":
                Clean();
                _infoPanel.SetActive(true);
                i = 0;
                select_[i].SetActive(true);
                PlayerPrefs.SetInt("index", i);
                stats[i].SetActive(true);
                break;
        }
    }
}
