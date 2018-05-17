using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public GameObject[] checkpoints;
    public int checkpointPointer;
    public GameManager gameManager;
    public GameObject player;
    public float totalPoints;

    public int currentLap;

    private void Update()
    {
        if (currentLap == 4)
        {
            gameManager.playerPlaces[gameManager.placeCounter] = player;
            gameManager.playerFinished = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == checkpoints[checkpoints.Length - 1] && checkpointPointer == checkpoints.Length - 1)
        {
            checkpointPointer = 0;
            currentLap++;
        }
        else if (collision.gameObject == checkpoints[checkpointPointer])
        {
            checkpointPointer++;
        }
    }
}