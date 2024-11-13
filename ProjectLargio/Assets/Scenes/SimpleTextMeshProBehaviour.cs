using TMPro;
using UnityEngine;

public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    public SimpleIntData dataObj;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScoreText(); // Initialize the score display
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + dataObj.score.ToString();
    }
}