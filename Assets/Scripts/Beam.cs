using UnityEngine;

public class Beam : MonoBehaviour
{
    public float RotationSpeed = 120;

    private void Start()
    {
        if (Random.value > 0.5f)
        {
            RotationSpeed *= -1;
        }

        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime, Space.Self);
    }
}
