using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public InputField playerName;
    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }
    public void SetPlayerName()
    {
        if (DataPresistance.Instance != null)
        {
            DataPresistance.Instance.PlayerName = playerName.text;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
