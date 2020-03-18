using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Variables that control spawning waves
    [Header("Wave Settings")]
    public GameObject hazard;       // What we are spawning.
    public Vector2 spawnValue;      // Where are we spawning?
    public int hazardCount;         // How many hazards are we spawning per wave?

    [Header("Wave Time Settings")]
    public float startWait;         // How long until the first wave.
    public float spawnWait;         // How long between each hazard in a wave.
    public float waveWait;          // How long between each wave.

    [Header("UI Elements")]
    public Text scoreText;

    // Variables for UI

    // Private variables
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to spawn waves of hazards
    IEnumerator SpawnWaves()
    {
        // Initial delay before the first wave
        yield return new WaitForSeconds(startWait);

        // Start spawning the waves
        while(true)
        {
            // Spawn some hazards
            for (int i = 0; i < hazardCount; i++)
            {
                // Spawn a single hazard
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); // Wait for the next hazard
            }

            yield return new WaitForSeconds(waveWait);  // Wait for the next wave of hazards
        }
    }

    // Update the score text (UI)
    private void UpdateScore()
    {
        // Update our UI elements to reflect the current score.
        scoreText.text = "Score: " + score;
    }

    // Accepts score value, increment the score, then updates the score
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // score = score + newScoreValue
        // We must call the UpdateScore function to update the score
        UpdateScore();
    }
}
