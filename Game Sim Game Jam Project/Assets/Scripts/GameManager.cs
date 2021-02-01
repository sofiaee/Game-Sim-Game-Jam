using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject escScreen;

    private void Awake()
    {
        Time.timeScale = 1;
        escScreen.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("LobbySceneFinal");
        Time.timeScale = 1;
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        escScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && !escScreen.activeSelf)
        {
            escScreen.SetActive(true);
            Time.timeScale = 0;
        } 
        else if (Input.GetKeyDown("escape") && escScreen.activeSelf)
        {
            escScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
