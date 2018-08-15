using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private float radius = 4;
    private float time;
    private float timeOffset;

    private void Start()
    {
        timeOffset = Random.Range(0, Mathf.PI * 2);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time < 5f)
        {
            float timeOffseted = time + timeOffset;
            transform.localPosition = new Vector3(Mathf.Sin(timeOffseted), Mathf.Cos(timeOffseted)) * radius;
            transform.localRotation = Quaternion.Euler(0, 0, 270 - Mathf.Rad2Deg * timeOffseted);

            radius += Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10, Space.Self);
        }
    }
}
