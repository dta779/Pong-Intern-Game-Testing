using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    public Button btnVsCom;
    public Button btn2Player;
    public Button btnExit;

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();

        if (btnVsCom != null)
            btnVsCom.onClick.AddListener(() => SceneManager.LoadScene("GameplayCom"));
            audioManager.playSFX(audioManager.start);

        if (btn2Player != null)
            btn2Player.onClick.AddListener(() => SceneManager.LoadScene("GameplayPlayer"));
            audioManager.playSFX(audioManager.start);

        if (btnExit != null)
            btnExit.onClick.AddListener(Application.Quit);
            audioManager.playSFX(audioManager.button);
    }
}