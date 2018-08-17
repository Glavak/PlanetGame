using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class StepsManager : MonoBehaviour
{
    [Serializable]
    public class StepConfig
    {
        public AnimationCurve ProbabilityFromTime = AnimationCurve.Constant(0, 300, 1);
        public GameObject Step;
    }

    public StepConfig[] StepConfigs;

    private GameObject currentStep;

    private void Update()
    {
        if (currentStep == null)
        {
            SpawnRandomStep();
        }
    }

    private void SpawnRandomStep()
    {
        float[] probabilitiesLimits = new float[StepConfigs.Length];

        for (int i = 0; i < probabilitiesLimits.Length; i++)
        {
            probabilitiesLimits[i] = StepConfigs[i].ProbabilityFromTime.Evaluate(Time.timeSinceLevelLoad);

            if (i > 0) probabilitiesLimits[i] += probabilitiesLimits[i - 1];
        }

        float diceDrop = Random.Range(0f, probabilitiesLimits[probabilitiesLimits.Length - 1]);

        for (int i = 0; i < probabilitiesLimits.Length; i++)
        {
            if (diceDrop <= probabilitiesLimits[i])
            {
                SpawnStep(StepConfigs[i].Step);
                break;
            }
        }
    }

    private void SpawnStep(GameObject step)
    {
        currentStep = Instantiate(step);
    }
}
