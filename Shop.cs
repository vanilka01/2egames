using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject buy;
    public GameObject _infoPanel;
    public GameObject NoMoney;
    public GameObject Purchased;

    private int i = 7;
    private int allCoins;
    private int cost;
    private int index;
    private int nal1;
    private int nal2;
    private int nal3;
    private int nal4;
    private int nal5;
    private int nal6;
    private int nal7;

    public Text allCoin;
    public Text allCoin2;

    public List<GameObject> stats;

    private void Start()
    {
        PlayerPrefs.Save();
        NoMoney.SetActive(false);
        Purchased.SetActive(false);
    }

    private void Update()
    {
        allCoin.text = PlayerPrefs.GetInt("allCoins").ToString();
        allCoin2.text = allCoin.text;
    }


    private void Clean()
    {
        for (int j = 0; j < stats.Count; j++)
        {
            stats[j].SetActive(false);
        }
        _infoPanel.SetActive(false);
        buy.SetActive(false);
        NoMoney.SetActive(false);
        Purchased.SetActive(false);
    }
    public void Buy()
    {
        index = PlayerPrefs.GetInt("ind");
        cost = PlayerPrefs.GetInt("cost");
        allCoins = PlayerPrefs.GetInt("allCoins");
        nal1 = PlayerPrefs.GetInt("nal1");
        nal2 = PlayerPrefs.GetInt("nal2");
        nal3 = PlayerPrefs.GetInt("nal3");
        nal4 = PlayerPrefs.GetInt("nal4");
        nal5 = PlayerPrefs.GetInt("nal5");
        nal6 = PlayerPrefs.GetInt("nal6");
        nal7 = PlayerPrefs.GetInt("nal7");
        if (allCoins >= cost)
        {
            if (index == 1 && nal1 != 1)
            {
                nal1 = 1;
                PlayerPrefs.SetInt("nal1", nal1);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 2 && nal2 != 1)
            {
                nal2 = 1;
                PlayerPrefs.SetInt("nal2", nal2);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 3 && nal3 != 1)
            {
                nal3 = 1;
                PlayerPrefs.SetInt("nal3", nal3);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 4 && nal4 != 1)
            {
                nal4 = 1;
                PlayerPrefs.SetInt("nal4", nal4);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 5 && nal5 != 1)
            {
                nal5 = 1;
                PlayerPrefs.SetInt("nal5", nal5);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 6 && nal6 != 1)
            {
                nal6 = 1;
                PlayerPrefs.SetInt("nal6", nal6);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            else if (index == 7 && nal7 != 1)
            {
                nal7 = 1;
                PlayerPrefs.SetInt("nal7", nal7);
                allCoins -= cost;
                Purchased.SetActive(true);
                PlayerPrefs.SetInt("index", index);
                PlayerPrefs.SetInt("allCoins", allCoins);
            }
            PlayerPrefs.Save();
        }
        else if (allCoins < cost)
        {
            NoMoney.SetActive(true);
        }
    }


    public void Shopping()
    {
        switch (gameObject.name)
        {
            case "guns_7":
                Clean();
                index = 7;
                i = index;
                cost = 1400;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                stats[i].SetActive(true);
                break;

            case "guns_6":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 6;
                i = index;
                cost = 1200;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_5":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 5;
                i = index;
                cost = 1000;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_2":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 2;
                i = index;
                cost = 900;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_3":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 3;
                i = index;
                cost = 600;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_4":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 4;
                i = index;
                cost = 400;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_1":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                index = 1;
                i = index;
                cost = 200;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "guns_0":
                Clean();
                _infoPanel.SetActive(true);
                index = 0;
                i = index;
                cost = 0;
                PlayerPrefs.SetInt("ind", index);
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "Back":
                SceneManager.LoadScene("Menu");
                break;

            case "Boosters":
                SceneManager.LoadScene("Boosters");
                break;
        }
    }
}