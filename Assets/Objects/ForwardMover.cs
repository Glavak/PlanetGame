using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    public float Speed = 10;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed, Space.Self);
    }
}
