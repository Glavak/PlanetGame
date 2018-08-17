using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// When collides with player, kills him and restarts the game
/// </summary>
public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            Invoke("Restart", 1);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
