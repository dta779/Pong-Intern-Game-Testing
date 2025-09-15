using UnityEngine;
public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float minVerticalSpeed = 1f;
    public Rigidbody2D rb;
    private GameManager gameManager;
    AudioManager audioManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindFirstObjectByType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f; 
        float y = Random.Range(-1f, 1f);            
        if (Mathf.Abs(y) < 0.3f)    
            y = y < 0 ? -0.5f : 0.5f;

        rb.linearVelocity = new Vector2(x, y).normalized * speed;
    }

    void Update()
    {
        //stop if ended
        if (gameManager != null && gameManager.gameEnded) return;

        Vector2 velocity = rb.linearVelocity;
        if (Mathf.Abs(velocity.y) < minVerticalSpeed)
        {
            float newY = velocity.y > 0 ? minVerticalSpeed : -minVerticalSpeed;
            velocity.y = newY;
            rb.linearVelocity = velocity.normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.playSFX(audioManager.ball);

        if (gameManager == null) return;

        if (other.CompareTag("TopWall"))
        {
            string winner = gameManager.isMultiplayer ? "PLAYER 1" : "PLAYER";
            gameManager.GameOver(winner);
            audioManager.playSFX(audioManager.win);
        }
        else if (other.CompareTag("BottomWall"))
        {
            string winner = gameManager.isMultiplayer ? "PLAYER 2" : "COMPUTER";
            gameManager.GameOver(winner);
            audioManager.playSFX(audioManager.win);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager != null && gameManager.gameEnded) return;

        audioManager.playSFX(audioManager.ball);

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Computer"))
        {
            Vector2 newVelocity = rb.linearVelocity;
            newVelocity.x += Random.Range(-0.2f, 0.2f);

            if (Mathf.Abs(newVelocity.y) < minVerticalSpeed)
            {
                newVelocity.y = newVelocity.y > 0 ? minVerticalSpeed : -minVerticalSpeed;
            }

            rb.linearVelocity = newVelocity.normalized * speed;
        }
    }
}