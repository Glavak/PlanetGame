using System.Collections;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float RotationSpeed = 120;
    public float BeamTime = 5;
    public bool RandomizeDirection;

    public GameObject Gun;
    public GameObject[] GunLeds;
    public GameObject BeamKiller;

    private float fullyAdvancedY;
    private Vector3 initialRotation;

    private IEnumerator Start()
    {
        if (RandomizeDirection && Random.value > 0.5f) RotationSpeed *= -1;
        fullyAdvancedY = Gun.transform.localPosition.y;
        initialRotation = transform.up;
        BeamKiller.SetActive(false);

        for (float t = 0; t < 1f; t += Time.deltaTime / 1.5f)
        {
            SetGunLedsProgress(t);
            float tSqr = t * t;
            transform.localRotation = Quaternion.LookRotation(Vector3.forward,
                Quaternion.Euler(0, 0, tSqr * RotationSpeed / 2) * initialRotation);
            yield return null;
        }

        SetGunLedsProgress(1);
        BeamKiller.SetActive(true);

        for (float t = 0; t < 1; t += Time.deltaTime / BeamTime)
        {
            transform.localRotation = Quaternion.LookRotation(Vector3.forward,
                Quaternion.Euler(0, 0, (t * BeamTime + .5f) * RotationSpeed) * initialRotation);
            yield return null;
        }

        BeamKiller.SetActive(false);

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            SetGunLedsProgress(1 - t);

            float tSqr = 1 - (1 - t) * (1 - t);
            transform.localRotation = Quaternion.LookRotation(Vector3.forward,
                Quaternion.Euler(0, 0, (tSqr + BeamTime*2 + 1) * RotationSpeed / 2) * initialRotation);
            yield return null;
        }

        Destroy(gameObject);
    }

    private void SetGunLedsProgress(float progress)
    {
        const float gunHeihgt = 1f;
        float gunProgress = Mathf.Clamp01(progress * 2) * gunHeihgt;
        Gun.transform.localPosition = Vector3.up * (fullyAdvancedY + gunHeihgt - gunProgress);

        float ledProgress = Mathf.Clamp01(progress * 2 - 1);
        for (int i = 0; i < GunLeds.Length; i++)
        {
            GunLeds[i].SetActive(i + 1 < ledProgress * (GunLeds.Length + 2));
        }
    }
}
