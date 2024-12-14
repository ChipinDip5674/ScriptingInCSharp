using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Include TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public GameObject congratsText; // Reference to the "Congrats" text GameObject
    public GameObject youLoseText; // Reference to the "You Lose" text GameObject
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI Text for the score
    public float restartDelay = 3f; // Time before restarting
    private int score = 0; // Player's score

    void Start()
    {
        UpdateScoreText(); // Initialize the score display
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
        congratsText.SetActive(true);
        Invoke("RestartGame", restartDelay);
    }

    public void LoseGame()
    {
        youLoseText.SetActive(true);
        Invoke("RestartGame", restartDelay);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }
}