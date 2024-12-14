using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public GameObject congratsText; // Reference to the "Congrats" text GameObject
    public GameObject youLoseText; // Reference to the "You Lose" text GameObject
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI Text for the score
    public AudioSource backgroundMusic; // Reference to the background music AudioSource
    public AudioSource winSound; // Reference to the win sound AudioSource
    public AudioSource deathSound; // Reference to the first death sound
    public AudioSource secondaryDeathSound; // Reference to the secondary death sound
    public float restartDelay = 3f; // Time before restarting
    private int score = 0; // Player's score

    void Start()
    {
        UpdateScoreText(); // Initialize the score display

        // Play background music if assigned
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }

        // Check if other AudioSources are assigned
        if (winSound == null || deathSound == null || secondaryDeathSound == null || backgroundMusic == null)
        {
            Debug.LogWarning("Some AudioSources are missing! Please assign them in the Inspector.");
        }
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score
        UpdateScoreText(); // Update the score display
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
    }

    public void EndGame()
    {
        // Stop the background music
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        // Play the win sound
        if (winSound != null && !winSound.isPlaying)
        {
            winSound.Play();
        }

        // Show "Congrats" text
        if (congratsText != null)
        {
            congratsText.SetActive(true);
        }

        // Restart the game after a delay
        Invoke("RestartGame", restartDelay);
    }

    public void LoseGame()
    {
        // Stop the background music
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        // Play the first death sound
        if (deathSound != null && !deathSound.isPlaying)
        {
            deathSound.Play();
        }

        // Schedule the secondary death sound to play after the first finishes
        if (secondaryDeathSound != null)
        {
            Invoke("PlaySecondaryDeathSound", deathSound.clip.length);
        }

        // Show "You Lose" text
        if (youLoseText != null)
        {
            youLoseText.SetActive(true);
        }

        // Restart the game after a delay
        Invoke("RestartGame", deathSound.clip.length + (secondaryDeathSound != null ? secondaryDeathSound.clip.length : 0f) + 1f);
    }

    private void PlaySecondaryDeathSound()
    {
        if (secondaryDeathSound != null && !secondaryDeathSound.isPlaying)
        {
            secondaryDeathSound.Play();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }
}