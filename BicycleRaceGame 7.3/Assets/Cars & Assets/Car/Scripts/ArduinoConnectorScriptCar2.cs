using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.CrossPlatformInput;

public class ArduinoConnectorScriptCar2 : MonoBehaviour {

    SerialPort sp = new SerialPort("COM4", 9600);
    bool cycling = false;
    float cycleKeeper;
    public GameManager gameManager;
    public int dFAI;
    public float gas;

	void Start () {
        sp.Open();
        sp.ReadTimeout = 1;
        dFAI = -1;
        gas = 0;
    }

    private void FixedUpdate()
    {
        string dataFromArduinoString = sp.ReadLine();

        dFAI = int.Parse(dataFromArduinoString);
    }

    void Update () {

        
        if (dFAI == 0)
        {
            gas = 1;
        }

        if (dFAI == -1)
        {
            gas -= 0.01f;
        }

        if (gas <= 0)
        {
            gas = 0;
        }

        if (sp.IsOpen)
        {
            try
            {
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
	}
}
