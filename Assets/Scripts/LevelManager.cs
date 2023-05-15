using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int sceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void LoadWireGame()
    {
        SceneManager.LoadScene("WireGame");
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public int ReturnSceneIndex()
    { 
        return sceneIndex;
    }

}
