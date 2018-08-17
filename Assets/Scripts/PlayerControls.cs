using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float RotationSpeed = 100;

    private void Update()
    {
        float rotation = InputManager.GetHorizontalAxis() * Time.deltaTime * RotationSpeed;

        transform.Rotate(0, 0, rotation);
    }
}
