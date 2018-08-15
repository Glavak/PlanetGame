using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Cooldown = 1;

    private float timeSinceShoot;

    private void Update()
    {
        if (timeSinceShoot > Cooldown)
        {
            timeSinceShoot -= Cooldown;

            Transform bullet = Instantiate(BulletPrefab, transform.position, transform.rotation).transform;

            bullet.Rotate(90,0,0,Space.Self);
        }

        timeSinceShoot += Time.deltaTime;
    }
}
