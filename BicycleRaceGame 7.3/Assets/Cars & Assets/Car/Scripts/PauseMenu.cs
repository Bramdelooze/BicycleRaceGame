using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    private bool FXLineOn = false;
    private bool musicLineOn = false;

    public GameObject pauseMenuUI;
    public GameObject FXLine;
    public GameObject musicLine;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Application.Quit();
    }

    public void FXClick()
    {
        if (!FXLineOn)
        {
            FXLineOn = true;
            FXLine.SetActive(true);
        }
        else
        {
            FXLine.SetActive(false);
            FXLineOn = false;
        }
    }

    public void MusicClick()
    {
        if (!musicLineOn)
        {
            musicLineOn = true;
            musicLine.SetActive(true);
        }
        else
        {
            musicLine.SetActive(false);
            musicLineOn = false;
        }

    }
}
