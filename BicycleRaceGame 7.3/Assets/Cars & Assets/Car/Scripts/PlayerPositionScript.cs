using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPositionScript : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    public Text p1Text;
    public Text p2Text;

    public int p1Position;
    public int p2Position;
    private int p1Lap;
    private int p2Lap;
    private int p1CurrentCheck;
    private int p2CurrentCheck;

    private float p1NextCheckDistance;
    private float p2NextCheckDistance;

	void Update () {
        p1Text.text = p1Position + "/2";
        p2Text.text = p2Position + "/2";

        p1Lap = player1.GetComponent<CheckPointScript>().currentLap;
        p2Lap = player2.GetComponent<CheckPointScript>().currentLap;

        p1CurrentCheck = player1.GetComponent<CheckPointScript>().checkpointPointer;
        p2CurrentCheck = player2.GetComponent<CheckPointScript>().checkpointPointer;

        p1NextCheckDistance = Vector3.Distance(player1.transform.position, player1.GetComponent<CheckPointScript>().checkpoints[p1CurrentCheck].transform.position);
        p2NextCheckDistance = Vector3.Distance(player2.transform.position, player2.GetComponent<CheckPointScript>().checkpoints[p2CurrentCheck].transform.position);

        if(p1Lap != p2Lap)
        {
            if (p1Lap > p2Lap)
            {
                p1Position = 1;
                p2Position = 2;
            }
            else
            {
                p1Position = 2;
                p2Position = 1;
            }
        }

        if(p1Lap == p2Lap && p1CurrentCheck != p2CurrentCheck)
        {
            if (p1CurrentCheck > p2CurrentCheck)
            {
                p1Position = 1;
                p2Position = 2;
            }
            else
            {
                p1Position = 2;
                p2Position = 1;
            }
        }

        if (p1Lap == p2Lap && p1CurrentCheck == p2CurrentCheck)
        {
            if (p1NextCheckDistance < p2NextCheckDistance)
            {
                p1Position = 1;
                p2Position = 2;
            }
            else
            {
                p1Position = 2;
                p2Position = 1;
            }
        }
    }
}