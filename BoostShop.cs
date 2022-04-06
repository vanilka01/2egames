using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoostShop : MonoBehaviour
{
    public List<GameObject> stats;

    public GameObject buy;
    public GameObject _infoPanel;
    public GameObject NoMoney;
    public GameObject Purchased;
    public GameObject alreadyHave;

    public Text allCoin;
    public Text allCoin2;

    private int b0;
    private int b1;
    private int b2;
    private int b3;
    private int cost;
    private int i;
    private int allCoins;
    private int SHgg;

    private void Start()
    {
        NoMoney.SetActive(false);
        b0 = PlayerPrefs.GetInt("b0");
        b1 = PlayerPrefs.GetInt("b1");
        b2 = PlayerPrefs.GetInt("b2");
        b3 = PlayerPrefs.GetInt("b3");
    }

    private void Update()
    {
        allCoin.text = PlayerPrefs.GetInt("allCoins").ToString();
        allCoin2.text = allCoin.text;
        Debug.Log(i);
        PlayerPrefs.Save();
    }
    private void Clean()
    {
        for (int j = 0; j < stats.Count; j++)
        {
            stats[j].SetActive(false);
        }
        NoMoney.SetActive(false);
        Purchased.SetActive(false);
        alreadyHave.SetActive(false);
    }

    public void Shopping()
    {
        switch (gameObject.name)
        {
            case "boosters_0":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                i = 0;
                PlayerPrefs.SetInt("indB", i);
                cost = 200;
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "boosters_1":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                i = 1;
                PlayerPrefs.SetInt("indB", i);
                cost = 400;
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "boosters_2":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                i = 2;
                PlayerPrefs.SetInt("indB", i);
                cost = 600;
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "boosters_3":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                i = 3;
                PlayerPrefs.SetInt("indB", i);
                cost = 800;
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "boosters_4":
                Clean();
                buy.SetActive(true);
                _infoPanel.SetActive(true);
                i = 4;
                PlayerPrefs.SetInt("indB", i);
                cost = 100;
                PlayerPrefs.SetInt("cost", cost);
                stats[i].SetActive(true);
                break;

            case "Shop":
                SceneManager.LoadScene("Shop");
                break;
        }
    }

    public void Buy()
    {
        cost = PlayerPrefs.GetInt("cost");
        allCoins = PlayerPrefs.GetInt("allCoins");
        b0 = PlayerPrefs.GetInt("b0");
        b1 = PlayerPrefs.GetInt("b1");
        b2 = PlayerPrefs.GetInt("b2");
        b3 = PlayerPrefs.GetInt("b3");
        i = PlayerPrefs.GetInt("indB");
        if(allCoins >= cost)
        {
            switch (i)
            {
                case 0:
                    if (b0 != 1)
                    {
                        b0 = 1;
                        PlayerPrefs.SetInt("b0", b0);
                        allCoins -= cost;
                        Purchased.SetActive(true);
                        PlayerPrefs.SetInt("allCoins", allCoins);
                    }
                    else
                    {
                        Purchased.SetActive(false);
                        alreadyHave.SetActive(true);
                    }
                    break;

                case 1:
                    if (b1 != 1)
                    {
                        b1 = 1;
                        PlayerPrefs.SetInt("b1", b1);
                        allCoins -= cost;
                        Purchased.SetActive(true);
                        PlayerPrefs.SetInt("allCoins", allCoins);
                    }
                    else
                    {
                        Purchased.SetActive(false);
                        alreadyHave.SetActive(true);
                    }
                    break;

                case 2:
                    if (b2 != 1)
                    {
                        b2 = 1;
                        PlayerPrefs.SetInt("b2", b2);
                        allCoins -= cost;
                        Purchased.SetActive(true);
                        PlayerPrefs.SetInt("allCoins", allCoins);
                    }
                    else
                    {
                        Purchased.SetActive(false);
                        alreadyHave.SetActive(true);
                    }
                    break;

                case 3:
                    if (b3 != 1)
                    {
                        b3 = 1;
                        PlayerPrefs.SetInt("b3", b3);
                        allCoins -= cost;
                        Purchased.SetActive(true);
                        PlayerPrefs.SetInt("allCoins", allCoins);
                    }
                    else
                    {
                        Purchased.SetActive(false);
                        alreadyHave.SetActive(true);
                    }
                    break;

                case 4:
                    SHgg = PlayerPrefs.GetInt("Shield");
                    PlayerPrefs.SetInt("Shield",SHgg + 1);
                    allCoins -= cost;
                    PlayerPrefs.SetInt("allCoins", allCoins);
                    break;
            }
            PlayerPrefs.Save();
        }
        else
        {
            alreadyHave.SetActive(false);
            NoMoney.SetActive(true);
        }
    }
}
