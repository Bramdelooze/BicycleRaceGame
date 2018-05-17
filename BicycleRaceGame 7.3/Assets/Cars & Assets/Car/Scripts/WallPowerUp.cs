using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPowerUp : MonoBehaviour {

    public GameObject wallBreak;
    public float destroyDelay;
    private bool colliding = false;
    public float moveSpeed;
    public float wallHeight;
    private float yPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        colliding = true;
    }

    private void Start()
    {
        yPos = transform.position.y;
    }

    private void Update()
    {
        if (transform.position.y < yPos + wallHeight)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (colliding)
        {            
            destroyDelay -= Time.deltaTime;
        }

        if (destroyDelay <= 0)
        {
            GameObject wallEffect = Instantiate(wallBreak, this.transform.position + (transform.up * 2.5f), transform.localRotation);
            Destroy(gameObject);
        }
    }
}