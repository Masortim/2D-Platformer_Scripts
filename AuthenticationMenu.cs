using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthenticationMenu : MonoBehaviour
{
    public Text playerDisplay;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}
