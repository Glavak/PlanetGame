using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float RotationSpeed = 100;

    public GameObject ExplosionPrefab;
    public Transform Visuals;

    private void Update()
    {
        float rotation = InputManager.GetHorizontalAxis() * Time.deltaTime * RotationSpeed;

        transform.Rotate(0, 0, rotation);
    }

    public void Explode()
    {
        Instantiate(ExplosionPrefab, Visuals.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
