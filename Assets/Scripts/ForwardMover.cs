using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    public AnimationCurve Speed = AnimationCurve.Constant(0, 10, 10);
    public Vector3 Multiplier = Vector3.up;

    private float time;

    private void Update()
    {
        transform.Translate(Multiplier * Speed.Evaluate(time) * Time.deltaTime, Space.Self);

        time += Time.deltaTime;
    }
}
