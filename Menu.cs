using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text allCoin;
    public Text allCoin2;
    private void Update()
    {
        allCoin.text = PlayerPrefs.GetInt("allCoins").ToString();
        allCoin2.text = allCoin.text;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(gameObject.name);
    }
    public void Boosters()
    {
        SceneManager.LoadScene("Boosters");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
