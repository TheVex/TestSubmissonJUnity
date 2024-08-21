using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public TMPro.TMP_InputField playerName;
    public void StartGame()
    {
        if (playerName.text.Length != 0)
        {
            SceneConnector.Instance.playerName = playerName.text;
        } else
        {
            SceneConnector.Instance.playerName = "Player";
        }
        SceneConnector.Instance.Load();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneConnector.Instance.Save();
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
