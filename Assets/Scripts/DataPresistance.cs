using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPresistance : MonoBehaviour
{
    public static DataPresistance Instance;
    public string PlayerName;
    public string HighScoreName = "Name";
    public int HighScore = 0;

    private void Awake()
    {
        //if Instance already exists then destroy this object
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //set Instance to this gameObject, prevent load destruction
        LoadHighScore();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public bool NewScore(int newScore)
    {
        if(newScore > HighScore)
        {
            HighScore = newScore;
            HighScoreName = PlayerName;
            SaveHighscore();
            return true;
        }
        return false;
    }
    [System.Serializable]
    class SaveData
    {
        public string HighScore_Name;
        public int HighScore_Score;
    }
    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.HighScore_Name = HighScoreName;
        data.HighScore_Score = HighScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.HighScore_Name;
            HighScore = data.HighScore_Score;
        }
    }
}
