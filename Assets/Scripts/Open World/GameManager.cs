using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;
    public static GameManager instance;
    public string nombrePong;
    public string bestNombrePong;
    public int bestPointsPong;

    void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void PausarAudio()
    {
        instance.audioSource.Pause();
    }
    public static void ReproducirAudio()
    {
        instance.audioSource.Play();
    }


    
}
