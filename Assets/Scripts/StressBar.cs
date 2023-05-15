using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    private Image stressBar;
    private void Start()
    {
        stressBar = GetComponent<Image>();
    }

    public void ShowStress(float value, int maxValue)
    {
        stressBar.fillAmount = value / maxValue;
    }
}