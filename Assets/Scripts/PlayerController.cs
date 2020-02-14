using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed;
    public float minX, minY, maxX, maxY;
    public GameObject laser;
    public GameObject laserSpawn;
    public float fireRate = 0.25f;

    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rBody.velocity = new Vector2(horiz, vert) * speed;

        // Restrict the player from leaving the play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, minX, maxX),  // Restricts x position to minX and maxX
            Mathf.Clamp(rBody.position.y, minY, maxY)); // Restricts y position to minY and maxY
    }

    void Update()
    {
        // Check if the "Fire" button is pressed
        if(Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            // If yes, spawn the laser
            GameObject go = GameObject.Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            go.transform.Rotate(new Vector3(0, 0, 90));

            // Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
