using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int chosenRace;
    public GameObject[] raceContainer;

    void Awake()
    {
        raceContainer[chosenRace - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
