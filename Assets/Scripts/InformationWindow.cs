using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationWindow : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private const int StartHeight = 50;
    [SerializeField] private int sentenceHeight;
    private float height;

    private void Start()
    {
        SetStartHeight();
        height = StartHeight;
    }

    public void IncreaseHeight()
    {
        rectTransform.sizeDelta = new Vector2(1500, height += sentenceHeight);
    }

    public void SetStartHeight()
    {
        rectTransform.sizeDelta = new Vector2(1500, StartHeight);
        height = StartHeight;
    }
}
