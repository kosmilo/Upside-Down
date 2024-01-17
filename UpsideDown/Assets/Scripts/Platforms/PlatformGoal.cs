using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneHandler))]
public class PlatformGoal : Platform
{
    SceneHandler sceneHandler;

    private void Start()
    {
        sceneHandler = GetComponent<SceneHandler>();
    }

    private void OnEnable()
    {
        OnActivate += FinishLevel;
    }

    public void FinishLevel(GameObject obj)
    {
        if (obj.name == "Player")
        {
            sceneHandler.NextScene();
        }
    }
}
