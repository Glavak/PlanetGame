using UnityEngine;

public class Beam : MonoBehaviour
{
    public float RotationSpeed = 120;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime, Space.Self);
    }
}
