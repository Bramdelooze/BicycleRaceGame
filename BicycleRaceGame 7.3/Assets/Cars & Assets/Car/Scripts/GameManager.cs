using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float time;
    public float timeRounded;
    public Text startText1;
    public Text startText2;
    public bool raceStarted = false;

    public bool playerFinished;
    public GameObject[] playerPlaces;
    public int placeCounter;

	// Use this for initialization
	void Start () {
        time = 5f;
        playerFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0.5)
        {
		    time -= Time.deltaTime;
            timeRounded = Mathf.Round(time);
            if(time < 3.5)
            {
                startText1.text = timeRounded.ToString();
                startText2.text = timeRounded.ToString();
            }
        }
        else
        {
            time -= Time.deltaTime;
            if (time > -2)
            {
                startText1.text = "GO!";
                startText2.text = "GO!";
                raceStarted = true;
            }
            else
            {
                startText1.text = "";
                startText2.text = "";
            }
        }

        if(playerFinished)
        {
            print("Player finished in place " + (placeCounter + 1));
            placeCounter++;
            playerFinished = false;
        }
	}
}
