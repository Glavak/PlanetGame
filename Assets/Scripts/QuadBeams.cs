using UnityEngine;

public class QuadBeams : MonoBehaviour
{
    private void Start()
    {
        if (Random.value > 0.5f)
        {
            foreach (Beam beam in GetComponentsInChildren<Beam>())
            {
                beam.RotationSpeed *= -1;
            }
        }
    }

    private void Update()
    {
        if (transform.childCount == 0) Destroy(gameObject);
    }
}
