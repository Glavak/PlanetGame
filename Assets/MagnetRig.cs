using System.Collections;
using Boo.Lang;
using UnityEngine;

public class MagnetRig : MonoBehaviour
{
    public Transform MagnetWithStand;
    public Transform MagnetTip;
    public float WorkTime = 8;
    public float AfterWorkTime = 7;

    public Asteroid AsteroidPrefab;

    private float fullyAdvancedY;
    private bool spawningAsteroids = true;

    private readonly List<Asteroid> spawnedAsteroids = new List<Asteroid>();

    private void Start()
    {
        fullyAdvancedY = MagnetWithStand.localPosition.y;
        StartCoroutine(WorkCoroutine());
    }

    private void Update()
    {
        MagnetTip.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 2) * 15);
    }

    private IEnumerator WorkCoroutine()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            SetAdvancePosition(t);
            yield return null;
        }
        SetAdvancePosition(1);

        yield return new WaitForSeconds(WorkTime);
        spawningAsteroids = false;

        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            SetAdvancePosition(1-t);
            yield return null;
        }
        SetAdvancePosition(0);

        yield return new WaitForSeconds(AfterWorkTime);

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (spawningAsteroids && Random.value < 1f * Time.fixedDeltaTime) SpawnAsteroid();

        spawnedAsteroids.RemoveAll(s => s == null);
        foreach (var asteroid in spawnedAsteroids)
        {
            asteroid.transform.Translate(asteroid.Velocity * Time.fixedDeltaTime, Space.World);
        }
    }

    private void OnDestroy()
    {
        foreach (var asteroid in spawnedAsteroids) Destroy(asteroid.gameObject);
    }

    private void SetAdvancePosition(float advance)
    {
        const float magnetHeihgt = 2.5f;

        advance = Mathf.Clamp01(advance);
        advance = 1 - (1 - advance) * (1 - advance);
        advance *= magnetHeihgt;
        MagnetWithStand.localPosition = Vector3.up * (fullyAdvancedY - magnetHeihgt + advance);
    }

    private void SpawnAsteroid()
    {
        float angle = Random.Range(-60, 60) * Mathf.Deg2Rad;
        Vector3 position = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * 30 + MagnetWithStand.position;
        Vector3 velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5 -
                           new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * 10;

        Asteroid asteroid = Instantiate(AsteroidPrefab, transform);
        asteroid.transform.localPosition = position;
        asteroid.Velocity = transform.localToWorldMatrix*velocity;
        spawnedAsteroids.Add(asteroid);
    }
}
