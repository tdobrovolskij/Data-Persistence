using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    public string PlayerName;
    public string BestPlayer;
    public int Highscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetHighscore(string player = "Name", int score = 0)
    {
        if (score > Highscore)
        {
            Highscore = score;
            BestPlayer = player;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        if (!string.IsNullOrEmpty(BestPlayer))
        {
            data.bestPlayer = BestPlayer;
        } else
        {
            return;
        }
            
        data.bestScore = Highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.bestPlayer;
            Highscore = data.bestScore;
        }
    }
}
