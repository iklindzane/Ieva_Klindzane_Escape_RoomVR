using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private List<HatOn> uncollectedHats; // Corrected variable name to match C# conventions
    private bool hasWon = false; // Set default value to false

    void Awake()
    {
        // Singleton pattern for GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Maintain GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    private void Start()
    {
        uncollectedHats = new List<HatOn>(FindObjectsOfType<HatOn>());
    }

    public void CollectedHat(HatOn hatOn)
    {
        if (hasWon) return;

        uncollectedHats.Remove(hatOn);

        if (uncollectedHats.Count == 0)
        {
            Victory(); // Call Victory method when all hats are collected
        }
    }

    private void Victory()
    {
        hasWon = true;
        Debug.Log(nameof(Victory)); // Log that the Victory method was called

        Invoke(nameof(RestartGame), 5f); // Use Invoke to call RestartGame after 5 seconds
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
