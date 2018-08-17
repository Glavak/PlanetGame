using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 12, 0);
    }
}
