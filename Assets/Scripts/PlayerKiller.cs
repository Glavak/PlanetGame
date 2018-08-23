using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// When collides with player, kills him and restarts the game
/// </summary>
public class PlayerKiller : MonoBehaviour
{
    public bool DestroySelf;
    public GameObject ExplosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerControls player = other.GetComponent<PlayerControls>();
            if (player != null) player.Explode();

            if (DestroySelf) Explode();
        }
    }

    public void Explode()
    {
        if (ExplosionPrefab != null) Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
