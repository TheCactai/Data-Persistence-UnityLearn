using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public bool NewScore(int newScore)
    {
        if(newScore > HighScore)
        {
            HighScore = newScore;
            HighScoreName = PlayerName;
            return true;
        }
        return false;
    }
}
