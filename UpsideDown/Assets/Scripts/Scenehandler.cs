using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextScene()
    {
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NextScene();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
