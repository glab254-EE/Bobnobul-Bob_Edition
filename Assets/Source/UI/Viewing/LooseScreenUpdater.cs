using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LooseScreenUpdater : MonoBehaviour
{
    private ForStringRounderer rounderer;
    private TMP_Text textLabel;
    void Start()
    {
        textLabel = GetComponent<TMP_Text>();
        rounderer = new();
    }
    void Update()
    {
        string scoreText = rounderer.RoundScoreFloat(GameStateManager.Score);
        string timeText = rounderer.RoundTimeFloat(GameStateManager.GlobalTimer);
        textLabel.text = "Your statistics:\nScore: " + scoreText + "\nTime: " + timeText;
    }
}

