using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.CrossPlatformInput;

public class ControlsManager : MonoBehaviour
{

    private ArduinoConnectorScriptCar arduino1;
    private ArduinoConnectorScriptCar2 arduino2;
    private CarController car1;
    private CarController2 car2;

    public bool keyControls;
    public bool joystickControls;
    public bool arduinoControls;

    private void Awake()
    {
        if (!keyControls && !joystickControls && !arduinoControls)
        {
            arduinoControls = true;
        }
    }

    private void Start()
    {
        arduino1 = FindObjectOfType<ArduinoConnectorScriptCar>();
        arduino2 = FindObjectOfType<ArduinoConnectorScriptCar2>();
        car1 = FindObjectOfType<CarController>();
        car2 = FindObjectOfType<CarController2>();
    }

    private void FixedUpdate()
    {
        // KeyControls P1
        float h1 = CrossPlatformInputManager.GetAxis("Horizontal");
        float v1 = CrossPlatformInputManager.GetAxis("Vertical");
        // KeyControls P2
        float h2 = CrossPlatformInputManager.GetAxis("Horizontal2");
        float v2 = CrossPlatformInputManager.GetAxis("Vertical2");
        // JoystickControls P1
        float hY1 = CrossPlatformInputManager.GetAxis("HorJoystick");
        float vY1 = CrossPlatformInputManager.GetAxis("VerJoystick");
        // JoystickControls P2
        float hY2 = CrossPlatformInputManager.GetAxis("HorJoystick2");
        float vY2 = CrossPlatformInputManager.GetAxis("VerJoystick2");
        // ArduinoGas P1
        float gas1 = arduino1.gas;
        // ArduinoGas P2
        float gas2 = arduino2.gas;

        float handbrake = CrossPlatformInputManager.GetAxis("Jump");

        if (keyControls)
        {
            car1.Move(h1, v1, v1, handbrake);
            car2.Move(h2, v2, v2, handbrake);
        }
        else if (joystickControls)
        {
            car1.Move(hY1, vY1, vY1, handbrake);
            car2.Move(hY2, vY2, vY2, handbrake);
        }
        else if (arduinoControls)
        {
            car1.Move(hY1, gas1, vY1, handbrake);
            car2.Move(hY2, gas2, vY2, handbrake);
        }
    }
}
