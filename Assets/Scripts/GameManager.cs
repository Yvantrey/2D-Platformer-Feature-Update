using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Lives")]
    public int lives = 3;

    [Header("References")]
    public Transform player;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private Rigidbody2D playerRB;
    private bool isRespawning = false;
    private Vector3 lastSafePosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (player != null)
        {
            playerRB = player.GetComponent<Rigidbody2D>();
            lastSafePosition = player.position;
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        // Removed lastSafePosition tracking
    }

    public void PlayerDied(Vector3 waterPosition)
    {
        if (isRespawning) return;
        
        isRespawning = true;
        lives--;

        if (lives > 0)
        {
            StartCoroutine(RespawnCoroutine(lastSafePosition));
        }
        else
        {
            GameOver();
        }
    }

    public void PlayerDiedAtCheckpoint(Vector3 checkpointPosition)
    {
        Debug.Log("PlayerDiedAtCheckpoint called with position: " + checkpointPosition);
        
        if (isRespawning) return;
        
        isRespawning = true;
        lives--;

        if (lives > 0)
        {
            Debug.Log("Starting respawn coroutine with position: " + checkpointPosition);
            StartCoroutine(RespawnCoroutine(checkpointPosition));
        }
        else
        {
            GameOver();
        }
    }

    System.Collections.IEnumerator RespawnCoroutine(Vector3 respawnPosition)
    {
        Debug.Log("RespawnCoroutine started with position: " + respawnPosition);
        
        if (player == null) yield break;

        player.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(0.5f);
        
        if (playerRB != null)
            playerRB.linearVelocity = Vector2.zero;
        
        Debug.Log("Setting player position to: " + respawnPosition);
        player.position = respawnPosition;
        player.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        isRespawning = false;
    }

    void GameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BossDefeated()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        Time.timeScale = 0f;
    }
}
