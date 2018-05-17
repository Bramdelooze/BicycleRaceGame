using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class PowerUps2 : MonoBehaviour {

    public CarController2 car;
    public ControlsManager controlsManager;
    public GameObject wall;
    public bool speedPowerUp;
    public bool wallPowerUp;
    public float powerUpDuration = 5f;
    public bool powerUpActivated;
    public float accelBooster;
    public float speedPower;
    public float slowDownValue;

    private Rigidbody rb;
    private ArduinoConnectorScriptCar2 arduino;

	// Use this for initialization
	void Start () {
        car = FindObjectOfType<CarController2>();
        arduino = FindObjectOfType<ArduinoConnectorScriptCar2>();
        rb = GetComponent<Rigidbody>();
        controlsManager = FindObjectOfType<ControlsManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // Acceleration boost when using Arrow keys
        if (car.CurrentSpeed <= 60 && Input.GetKey(KeyCode.UpArrow) && controlsManager.keyControls)
        {
            rb.AddForce(transform.forward * accelBooster, ForceMode.Impulse);
        }
        // Acceleration boost when biking
        if (car.CurrentSpeed <= 60 && car.CurrentSpeed >= 10 && arduino.gas >= .9f && controlsManager.arduinoControls)
        {
            rb.AddForce(transform.forward * accelBooster, ForceMode.Impulse);
        }
        //Speed Power Up
        if (speedPowerUp && !powerUpActivated)
        {
            if (Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Joystick2Button0)))
            {
                car.topSpeedChanger = 200f;
                rb.AddForce(transform.forward * speedPower, ForceMode.Impulse);
                powerUpActivated = true;
            }
        }

        if (wallPowerUp && !powerUpActivated && Input.GetKeyDown(KeyCode.E) || wallPowerUp && !powerUpActivated && (Input.GetKeyDown(KeyCode.Joystick2Button0)))
        {
            float offsetBehind = -1.75f;
            float offsetUp = -5.1f;
            GameObject wallObstacle = Instantiate(wall, (this.transform.position - (-transform.forward * offsetBehind)) + (transform.up * offsetUp), transform.rotation) as GameObject;
            wallPowerUp = false;
        }

        if (powerUpActivated)
        {
            rb.AddForce(transform.forward * speedPower, ForceMode.Impulse);
            powerUpDuration -= Time.deltaTime;
            if (powerUpDuration <= 0)
            {
                powerUpActivated = false;
                powerUpDuration = 5;
                car.topSpeedChanger = 180f;
                speedPowerUp = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUps")
        {
            if (!speedPowerUp && !wallPowerUp)
            {
                if (other.gameObject.name == "speedpowerup(Clone)")
                {
                    speedPowerUp = true;
                }
                if (other.gameObject.name == "wallpowerup(Clone)")
                {
                    wallPowerUp = true;
                }
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "WallObstacle")
        {
            rb.velocity = new Vector3((rb.velocity.x / slowDownValue), rb.velocity.y, (rb.velocity.z / slowDownValue));
        }
    }
}