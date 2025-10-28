using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TimerLabelHandler : MonoBehaviour
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
        textLabel.text = rounderer.RoundTimeFloat(GameStateManager.GlobalTimer);
    }
}

