using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [Header("Object Stats")]
    public int scoreValue = 10;
    [Header("Explosions")]
    public GameObject explosion;
    public GameObject explosion_player;

    // Private variables
    private GameController gameControllerComponent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if(gameControllerObj != null)
        {
            // The object exists
            gameControllerComponent = gameControllerObj.GetComponent<GameController>();
        }
        if(gameControllerComponent == null)
        {
            Debug.Log("Cannot find the Game Controller component on the Game Controller object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect when another object collides with this object
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the other object is the player
        if(other.gameObject.CompareTag("Player"))
        {
            // Collided with the player
            Instantiate(explosion_player, other.transform.position, other.transform.rotation);
        }

        // Increment our score value
        gameControllerComponent.AddScore(scoreValue);

        // Create and position the explosion
        Instantiate(explosion, transform.position, transform.rotation);

        // Delete the "other" object
        // Delete this object
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
