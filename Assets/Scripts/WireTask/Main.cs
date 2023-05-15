using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int switchCount;
    //public GameObject winText;
    private int onCount = 0;
    [SerializeField] private UnityEvent OnWon;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            //winText.SetActive(true);
            OnWon.Invoke();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
