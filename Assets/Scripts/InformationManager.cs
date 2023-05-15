using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Newtonsoft.Json.Linq;
using System;

public class InformationManager : MonoBehaviour
{
    //[SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text informationText;
    [SerializeField] private InformationWindow informationWindow;
    //[SerializeField] NameWindow nameWindow;
    private Queue<string> sentenses;
    private int numberOfLetters = 0;
    [SerializeField] private float timeBetweenLetters;
    public int lettersInSentence;

    [SerializeField] private UnityEvent EndWriting;

    public UnityEvent NewLine;
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void ShowInformation(Room information)
    {
        sentenses.Clear();
        //nameText.text = information.name;

        foreach (string sentence in information.Description)
        {
            sentenses.Enqueue(sentence);
        }
        //nameWindow.SetWight(information.name.ToCharArray());
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenses.Count == 0)
        {
            HideInformation();
            return;
        }

        string sentence = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentence));
    }

    IEnumerator TypeSentense(string sentence)
    {
        informationText.text = "";
        //foreach (char letter in sentence.ToCharArray())
        //{

        //}
        informationWindow.SetStartHeight();
        //NewLine.Invoke();
        foreach (char letter in sentence.ToCharArray())
        {
            numberOfLetters++;
            informationText.text += letter;
            if (numberOfLetters >= lettersInSentence)
            {
                numberOfLetters = 0;
                NewLine.Invoke();
            }
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        EndWriting.Invoke();
    }

    public void HideInformation()
    {
        StopAllCoroutines();
        informationText.text = "";
        //nameText.text = "";
    }

    //public char[] CharsInName(Room information)
    //{
    //    return information.name.ToCharArray();
    //}

    public void SetWritingSpeed(float value) => timeBetweenLetters = value;
}
