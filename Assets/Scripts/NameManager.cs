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

    public void SaveScore(int score)
    {

    }
}
