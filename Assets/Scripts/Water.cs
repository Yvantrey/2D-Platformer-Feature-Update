using UnityEngine;

public class Water : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && respawnPoint != null)
        {
            GameManager.instance.lives--;
            
            if (GameManager.instance.lives > 0)
            {
                other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                other.transform.position = respawnPoint.position;
            }
            else
            {
                other.gameObject.SetActive(false);
                GameManager.instance.gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
