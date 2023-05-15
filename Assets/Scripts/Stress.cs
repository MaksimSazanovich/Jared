using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    [SerializeField] private int maxStressCount = 10;
    [SerializeField] private float stressCount;
    public float StressCount { get => stressCount; }

    [SerializeField] private StressBar stressBar;

    public void ChangeStressCount(int value)
    {
        stressCount += value;
        if (stressCount >= 0) stressCount = 10;
        if(stressCount <= 0) stressCount = 0;
        stressBar.ShowStress(stressCount, maxStressCount);
    }
}