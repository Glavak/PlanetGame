using UnityEngine;

public class CrosshairStep : MonoBehaviour
{
    public GameObject CrosshairPrefab;
    public int CountToSpawn = 4;

    private Transform player;
    private Transform spawnedObject;
    private float timeToSpawn;
    private int countSpawned;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void SpawnCrosshair()
    {
        spawnedObject = Instantiate(CrosshairPrefab, Vector3.zero, player.localRotation).transform;

        countSpawned++;
    }

    private void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn <= 0 && countSpawned < CountToSpawn)
        {
            SpawnCrosshair();
            timeToSpawn = .65f;
        }

        if (spawnedObject == null && countSpawned >= CountToSpawn)
        {
            Destroy(gameObject);
        }
    }
}
