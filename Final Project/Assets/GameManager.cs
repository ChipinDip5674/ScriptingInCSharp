using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject congratsText; // Reference to the "Congrats" text GameObject
    public float restartDelay = 3f; // Time before restarting

    public void EndGame()
    {
        // Show "Congrats" text
        congratsText.SetActive(true);

        // Restart the game after a delay
        Invoke("RestartGame", restartDelay);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }
}