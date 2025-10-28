using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreViewerHandler : MonoBehaviour
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
        textLabel.text = "Score: "+rounderer.RoundScoreFloat(GameStateManager.Score);
    }
}
