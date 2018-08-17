using System.Collections;
using UnityEngine;

public class FlashAndSpawn : MonoBehaviour
{
    public GameObject SpawnObjectPrefab;
    public GameObject Visuals;

    public float FlashTime = 2.3f;
    public float ObjectTime = 2f;

    private void Start()
    {
        StartCoroutine(FlashAndSpawnCoroutine());
    }

    private IEnumerator FlashAndSpawnCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(FlashTime / 10);
            Visuals.SetActive(!Visuals.activeSelf);
        }

        GameObject killerCircle = Instantiate(SpawnObjectPrefab, Vector3.zero, transform.rotation);

        Visuals.SetActive(false);
        yield return new WaitForSeconds(ObjectTime);

        Destroy(gameObject);
        Destroy(killerCircle);
    }
}
