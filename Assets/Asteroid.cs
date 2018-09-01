using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 direction;

    private float lifetime = 10;

    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
        float scale = Random.Range(.6f, 2f);

        transform.GetChild(0).localRotation = rotation;
        transform.GetChild(0).localScale = Vector3.one * scale;

        const float radius = 30f;
        direction = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius)) - transform.localPosition;
        direction.Normalize();
        direction *= Random.Range(15f, 25f);
    }

    private void FixedUpdate()
    {
        transform.localPosition += Time.fixedDeltaTime * direction;

        if (lifetime > 0)
        {
            Vector3 gravityDirection = Vector3.zero - transform.localPosition;
            float gravityScale = 500f / transform.localPosition.sqrMagnitude;
            direction += gravityDirection * Time.fixedDeltaTime * gravityScale; // Kinda gravity
        }

        if (lifetime < -10) Destroy(gameObject);

        lifetime -= Time.fixedDeltaTime;
    }
}
