using System.Collections;
using UnityEngine;

public class CrosshairStep : MonoBehaviour
{
    public GameObject CrosshairPrefab;
    public Beam BeamPrefab;
    public int CountToSpawn = 4;

    private Transform player;
    private float timeToSpawn;

    private IEnumerator Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        for (int i = 0; i < CountToSpawn; i++)
        {
            yield return new WaitForSeconds(.65f);
            SpawnCrosshair();
        }

        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }

    private void SpawnCrosshair()
    {
        if(player == null) return;

        Instantiate(CrosshairPrefab, Vector3.zero, player.localRotation);

        Beam beam = Instantiate(BeamPrefab, Vector3.zero, player.localRotation);
        beam.RotationSpeed = 0;
        beam.BeamTime = 2;
    }
}
