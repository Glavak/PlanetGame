using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

        Invoke("Restart", 1);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
