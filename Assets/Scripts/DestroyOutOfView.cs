using UnityEngine;

public class DestroyOutOfView : MonoBehaviour
{
    private const float ScreenRadius = 50;

    private void Update()
    {
        if (transform.position.sqrMagnitude > ScreenRadius*ScreenRadius) Destroy(gameObject, 0.5f);
    }
}
