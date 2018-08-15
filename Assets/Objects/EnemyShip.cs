using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private float radius = 4;
    private float time;

    private void Start()
    {
        time = Random.Range(0, Mathf.PI * 2);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time < 5f)
        {
            transform.localPosition = new Vector3(Mathf.Sin(time), Mathf.Cos(time)) * radius;
            transform.localRotation = Quaternion.Euler(0, 0, 270 - Mathf.Rad2Deg * time);

            radius += Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10, Space.Self);
        }
    }
}
