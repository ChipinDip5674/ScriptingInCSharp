using UnityEngine;

public class SimpleIntData : MonoBehaviour
{
    public int score = 0;
    public SimpleTextMeshProBehaviour uiUpdater; // Reference to the UI updater

    public void UpdateValue(int value)
    {
        score += value;
        Debug.Log("Fruit collected! Current Score: " + score);

        // Update the score display on the UI
        if (uiUpdater != null)
        {
            uiUpdater.UpdateScoreText();
        }
    }
}