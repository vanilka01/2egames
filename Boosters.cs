using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosters : MonoBehaviour
{
    public List<GameObject> boosters;

    private float spawnBoostTimer = 0;

    public static int countBoosters = 0;
    private int[] b = new int[4];
    public GameObject[] boosts = new GameObject[4];

    private void Start()
    {
        boosters.Clear();
        PlayerPrefs.Save();
        b[0] = PlayerPrefs.GetInt("b0");
        b[1] = PlayerPrefs.GetInt("b1");
        b[2] = PlayerPrefs.GetInt("b2");
        b[3] = PlayerPrefs.GetInt("b3");
        for(int i = 0; i < 4; i++)
        {
            if(b[i] == 1)
            {
                boosters.Add(boosts[i]);
            }
        }
    }

    private void Update()
    {
        Debug.Log("boost  " + boosters.Count);
        Vector3 SpawnPoint = new Vector3(Random.Range(-70, 70), Random.Range(-35, 35), 100);
        spawnBoostTimer += Time.deltaTime;
        if (spawnBoostTimer > 15 && countBoosters < 4 && boosters.Count > 0)
        {
            Instantiate(boosters[Random.Range(0, boosters.Count)], SpawnPoint, Quaternion.identity);
            countBoosters++;
            spawnBoostTimer = 0;
        }
    }
}
