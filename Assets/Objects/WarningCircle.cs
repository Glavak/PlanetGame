using System.Collections;
using UnityEngine;

public class WarningCircle : MonoBehaviour
{
    public GameObject KillerCirclePrefab;

    private void Start()
    {
        StartCoroutine(FlashAndSpawnCoroutine());
    }

    private IEnumerator FlashAndSpawnCoroutine()
    {
        yield return new WaitForSeconds(2.3f);

        GameObject killerCircle = Instantiate(KillerCirclePrefab, Vector3.zero, transform.rotation);

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        Destroy(killerCircle);
    }
}
