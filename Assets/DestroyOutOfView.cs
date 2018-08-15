using UnityEngine;

public class DestroyOutOfView : MonoBehaviour
{
    private Renderer componentRenderer;

    private void Start()
    {
        componentRenderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        if (!componentRenderer.isVisible) Destroy(gameObject, 0.5f);
    }
}
