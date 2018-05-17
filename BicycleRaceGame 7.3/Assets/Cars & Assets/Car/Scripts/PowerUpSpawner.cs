using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public float spawnDelay = 1f;
    public float timer;
    public GameObject powerUpPrefab;
    private Vector3 powerUpPosOffset = new Vector3(0f, 1.59f, 0f);

	// Use this for initialization
	void Awake () {
        transform.position += powerUpPosOffset;
        SpawnPowerUp();
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            timer += Time.deltaTime;
            if(timer >= spawnDelay)
            {
                SpawnPowerUp();
                timer = 0;
            }
        }
    }

    void SpawnPowerUp()
    {
        GameObject powerUp = Instantiate(powerUpPrefab, transform.position, Quaternion.identity) as GameObject;
        powerUp.transform.parent = gameObject.transform;
    }
}