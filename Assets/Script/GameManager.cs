using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject darkPanel;
    public Text txtName;
    public Button btnRestart;
    public Button btnMainMenu;

    [Header("Ball")]
    public Rigidbody2D ballRb;

    [Header("Paddles")]
    public ComPad computerPaddle; 
    public PlayerPad playerPaddle;
    public PlayerPad player2Paddle; 

    [Header("Game Mode")]
    public bool isMultiplayer = false;

    public bool gameEnded = false;

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        
        darkPanel.SetActive(false);

        if (btnRestart != null)
            btnRestart.onClick.AddListener(RestartGame);
            audioManager.playSFX(audioManager.button);

        if (btnMainMenu != null)
            btnMainMenu.onClick.AddListener(GoToMainMenu);
            audioManager.playSFX(audioManager.button);
    }

    public void GameOver(string winner)
    {
        if (audioManager != null)
            audioManager.musicSource.Stop();

        if (gameEnded) return;
            gameEnded = true;

        darkPanel.SetActive(true);

        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector2.zero;
            ballRb.angularVelocity = 0f;
        }

        if (isMultiplayer)
        {
            if (playerPaddle != null) playerPaddle.enabled = false;
            if (player2Paddle != null) player2Paddle.enabled = false;
        }
        else
        {
            if (computerPaddle != null) computerPaddle.enabled = false;
            if (playerPaddle != null) playerPaddle.enabled = false;
        }

      
       txtName.text = winner;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
