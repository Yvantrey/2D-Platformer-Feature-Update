using UnityEngine;

public class Water : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (respawnPoint != null)
            {
                GameManager.instance.PlayerDiedAtCheckpoint(respawnPoint.position);
            }
            else
            {
                GameManager.instance.PlayerDied(transform.position);
            }
        }
    }
}
