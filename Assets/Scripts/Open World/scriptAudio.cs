using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAudio : MonoBehaviour
{
    AudioSource audioSource;
    public static scriptAudio instance;

    void Awake()
    {
        if(scriptAudio.instance == null)
        {
            scriptAudio.instance = this;
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
