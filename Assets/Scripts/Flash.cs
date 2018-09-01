using UnityEngine;

public class Flash : MonoBehaviour
{
    public float FlashingTime = 1;
    public GameObject Visuals;

    private float periodStart;
    private float periodEnd;
    private float currentTime;
    private float timeInCurrentState;

    private void Start()
    {
        periodStart = FlashingTime / 4;
        periodEnd = periodStart / 10;
    }

    private void Update()
    {
        timeInCurrentState += Time.deltaTime;
        currentTime += Time.deltaTime;

        float currentPeriod = Mathf.Lerp(periodStart, periodEnd, currentTime / FlashingTime);
        if (timeInCurrentState >= currentPeriod)
        {
            Visuals.SetActive(!Visuals.activeSelf);
            timeInCurrentState = 0;
        }

        if (currentTime > FlashingTime)
        {
            Destroy(gameObject);
        }
    }
}
