using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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

    [Serializable]
    class BestScorePong{
        public int score;
        public string name;
    }

    public void SaveScorePong(){
        BestScorePong data = new BestScorePong();
        data.name = bestNombrePong;
        data.score = bestPointsPong;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFilePong.json", json);
    }

    public void LoadScorePong(){
        string path = Application.persistentDataPath + "/saveFilePong.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            BestScorePong data = JsonUtility.FromJson<BestScorePong>(json);
            bestNombrePong = data.name;
            bestPointsPong = data.score;
        }
        else{
            bestNombrePong = "NA";
            bestPointsPong = 0;
        }
    }
}
