using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaMainMenu : MonoBehaviour
{
    public GameObject m_music;
    static bool AudioBegin = false;

    private void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(this.m_music);
            AudioBegin = true;
        }
    }

    private void Update()
    {
        PlayingMMM();
    }

    public void PlayingMMM()
    {
        if (SceneManager.GetActiveScene().name == "PrimerNivel")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
    }
}
