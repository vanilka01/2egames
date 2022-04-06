using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicMenu : MonoBehaviour
{
    public new GameObject gameObject;

    public new AudioSource audio;

    public AudioMixerGroup music;
    public AudioMixerGroup effects;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
        {
            Destroy();
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        music.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("MusicVolume")));
        effects.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("EffectsVolume")));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Play" || scene.name == "Lose")
            audio.mute = true;
        else
            audio.mute = false;
    }

    void Destroy()
    {
        Destroy(gameObject);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
