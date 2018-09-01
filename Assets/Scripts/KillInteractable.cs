using UnityEngine;

public class KillInteractable : MonoBehaviour
{
    public bool KillPlayer;
    public bool KillEnemy;
    public bool DestroyOnImpact = true;

    public bool DieFromPlanet;
    public bool DamagePlanet;

    public GameObject ExplosionPrefab;

    private bool exploded;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.enabled) return;

        if (KillEnemy && other.gameObject.CompareTag("Enemy"))
        {
            Explode();

            KillInteractable killInteractable = other.gameObject.GetComponent<KillInteractable>();
            if (killInteractable != null) killInteractable.Explode();
            else Destroy(other.gameObject);
        }
        else if (KillPlayer && other.gameObject.CompareTag("Player"))
        {
            Explode();

            PlayerControls player = other.gameObject.GetComponent<PlayerControls>();
            if (player != null) player.Explode();
        }
        else if (DieFromPlanet && other.gameObject.CompareTag("Planet"))
        {
            Explode();

            if (DamagePlanet) GameData.Instance.Expirience += 1;
        }
    }

    public void Explode()
    {
        if (!DestroyOnImpact || exploded) return;
        exploded = true;

        if (ExplosionPrefab != null) Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

        Destroy(this.gameObject, .1f);
    }
}
