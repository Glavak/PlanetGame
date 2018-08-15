using UnityEngine;

/// <summary>
/// When hits enemy, destroys it and itself. Also self-destroy on hit with planet
/// </summary>
public class EnemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Planet"))
        {
            Destroy(this.gameObject);
        }
    }
}
