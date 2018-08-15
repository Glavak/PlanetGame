using UnityEngine;

public class SpawnStep : MonoBehaviour
{
    public GameObject Prefab;
    public bool RandomizeRotation;

    private Transform spawnedObject;

    private void Start()
    {
        spawnedObject = Instantiate(Prefab, Vector3.zero, Quaternion.identity).transform;

        if (RandomizeRotation) spawnedObject.Rotate(0, 0, Random.Range(0, 360f), Space.Self);
    }

    private void Update()
    {
        if (spawnedObject == null)
        {
            Destroy(gameObject);
        }
    }
}
