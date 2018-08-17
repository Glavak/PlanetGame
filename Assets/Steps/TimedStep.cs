using UnityEngine;

public class TimedStep : MonoBehaviour
{
    public float TimeTotal = 3;

    private float timePassed;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > TimeTotal)
        {
            Destroy(gameObject);
        }
    }
}
