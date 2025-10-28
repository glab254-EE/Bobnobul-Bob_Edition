using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static float GlobalTimer { get; private set; } = 0;
    public static float Score { get; private set; } = 0;
    public static bool IsPlaying { get; private set; } = false;
    void Start()
    {
        Score = 0;
        IsPlaying = false;
        GlobalTimer = 0;
    }
    void Update()
    {
        if (IsPlaying)
        {
            GlobalTimer += Time.deltaTime;
        }
    }
    internal static void ChangePlayingState(bool state) => IsPlaying = state;
    internal static void AddScore(float score) {
        if (IsPlaying)
        {
            Score += score;
        }
    }
}
