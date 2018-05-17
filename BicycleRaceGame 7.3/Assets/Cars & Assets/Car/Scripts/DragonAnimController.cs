using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class DragonAnimController : MonoBehaviour {

	public Animator dragonAnim;
    private CarController car;
    private bool flyingAnim;
    private bool idleAnim;

	// Use this for initialization
	void Start () {
		dragonAnim = GetComponent<Animator> ();
        car = FindObjectOfType<CarController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (car.CurrentSpeed > 10f)
        {
            if (!flyingAnim)
            {
                dragonAnim.CrossFade ("Flying", 0.3f);
                idleAnim = false;
                flyingAnim = true;
            }
            dragonAnim.speed = .017f * car.CurrentSpeed;
        }

        if (car.CurrentSpeed < 10f)
		{
            if (!idleAnim)
            {
			    dragonAnim.CrossFade ("Idle", 0.3f);
                flyingAnim = false;
                idleAnim = true;
            }
            dragonAnim.speed = 1f;
		}
    }
}