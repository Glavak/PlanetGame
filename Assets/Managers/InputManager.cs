using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float axisPosition;
    private float axisTargetPosition;
    private static InputManager instance;

    public static float GetHorizontalAxis()
    {
        return Mathf.Clamp(Input.GetAxisRaw("Horizontal") + instance.axisTargetPosition, -1, 1);
    }

    public static void SetHorizontalVirtualAxis(float targetPosition)
    {
        instance.axisTargetPosition = targetPosition;
    }

    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("Two InputManagers");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Update()
    {
        axisPosition = Mathf.MoveTowards(axisPosition, axisTargetPosition, Time.deltaTime * 3);

        axisTargetPosition = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) continue;

            if (Camera.main.ScreenToViewportPoint(touch.position).x < 0.5) axisTargetPosition--;
            else axisTargetPosition++;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.5) axisTargetPosition--;
            else axisTargetPosition++;
        }
#endif
    }
}
