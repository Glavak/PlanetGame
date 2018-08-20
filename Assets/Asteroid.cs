using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector3 Velocity;

    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
        float scale = Random.Range(.6f, 2f);

        transform.GetChild(0).localRotation = rotation;
        transform.GetChild(0).localScale = Vector3.one * scale;
    }
}
