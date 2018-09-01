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
    }

    private void SetAdvancePosition(float advance)
    {
        const float magnetHeihgt = 3f;

        advance = Mathf.Clamp01(advance);
        advance = 1 - (1 - advance) * (1 - advance);
        advance *= magnetHeihgt;
        MagnetWithStand.localPosition = Vector3.up * (fullyAdvancedY - magnetHeihgt + advance);
    }

    private void SpawnAsteroid()
    {
        float angle = Random.Range(-60, 60) * Mathf.Deg2Rad;
        Vector3 position = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * 36 + MagnetWithStand.localPosition;

        Asteroid asteroid = Instantiate(AsteroidPrefab, transform);
        asteroid.transform.localPosition = position;
        asteroid.transform.SetParent(null, true);
    }
}
