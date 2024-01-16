using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGoal : Platform
{
    private void OnEnable()
    {
        OnActivate += FinishLevel;
    }

    public void FinishLevel(GameObject obj)
    {
        if (obj.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
