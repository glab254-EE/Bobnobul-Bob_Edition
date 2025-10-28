using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LooseScreenHandler : MonoBehaviour
{
    [field: SerializeField]
    private GameObject LoseFrame;
    [field: SerializeField]
    private Button ResetButton;
    bool gameStarted = false;
    void Start()
    {
        ResetButton?.onClick.AddListener(OnButtonpress);
    }
    void FixedUpdate()
    {
        if (!gameStarted)
        {
            gameStarted = GameStateManager.IsPlaying;
            return;
        }
        LoseFrame.SetActive(!GameStateManager.IsPlaying);
    }
    void OnButtonpress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
