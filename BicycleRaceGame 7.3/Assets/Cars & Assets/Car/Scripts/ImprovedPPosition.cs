using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedPPosition : MonoBehaviour {

    public GameObject[] players;
    //public List<GameObject> playerPositions;

    public int arrayPointer = 0;

    private int[] playerLaps;
    private int[] playersCurrentCheck;
    private float[] playersNextCheckDistance;
    public float[] totalPoints;
    private List<float> totalPointslist;

    private void Awake()
    {
        print(players.Length);
        playerLaps = new int[players.Length];
        playersCurrentCheck = new int[players.Length];
        playersNextCheckDistance = new float[players.Length];
        totalPoints = new float[players.Length];
    }

    void Update() {
        checkLaps();
        checkCurrentCheckpoint();
        checkNextCheckpointDistance();
        totalPoints[arrayPointer] = (playerLaps[arrayPointer] + playersCurrentCheck[arrayPointer] - playersNextCheckDistance[arrayPointer]);
        players[arrayPointer].GetComponent<CheckPointScript>().totalPoints = totalPoints[arrayPointer];
        arrayPointer++;

        if (arrayPointer == players.Length)
        {
            arrayPointer = 0;
        }
        //totalPoints.Sort();
    }

    private void checkLaps()
    {
        playerLaps[arrayPointer] = players[arrayPointer].GetComponent<CheckPointScript>().currentLap * 100;
        //Multiplier so that the checkpoint number don't mess up the counter (Unless you have more than 100 checkpoints)
    }

    private void checkCurrentCheckpoint()
    {
        playersCurrentCheck[arrayPointer] = players[arrayPointer].GetComponent<CheckPointScript>().checkpointPointer;
    }

    private void checkNextCheckpointDistance()
    {
        playersNextCheckDistance[arrayPointer] =
            Vector3.Distance(players[arrayPointer].transform.position,
            players[arrayPointer].GetComponent<CheckPointScript>().checkpoints[playersCurrentCheck[arrayPointer]].transform.position) /1000;
    }
}