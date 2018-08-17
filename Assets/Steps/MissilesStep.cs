using System.Collections.Generic;
using UnityEngine;

public class MissilesStep : MonoBehaviour
{
    public GameObject MissilePrefab;
    public int MissileCount = 10;

    public int BurstsCount = 5;
    public float BurstInterval = 0.2f;

    private float burstTimer;
    private float burstsCompleted;

    private readonly List<Transform> spawnedObjects = new List<Transform>();

    private void Update()
    {
        if (burstTimer < 0 && burstsCompleted < BurstsCount)
        {
            burstTimer += BurstInterval;
            Burst();

            burstsCompleted++;
        }

        burstTimer -= Time.deltaTime;

        spawnedObjects.RemoveAll(o => o == null);
        if (burstsCompleted >= BurstsCount && spawnedObjects.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Burst()
    {
        for (int i = 0; i < MissileCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 360f * i / MissileCount + burstsCompleted * 7);
            Transform missile = Instantiate(MissilePrefab, Vector3.zero, rotation).transform;
            missile.Translate(Vector3.up * 5, Space.Self);

            spawnedObjects.Add(missile);
        }
    }
}
