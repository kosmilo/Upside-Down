using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager eventSystemInstance;

    private void Awake() {
        if (eventSystemInstance != null && eventSystemInstance != this)
        {
            Destroy(gameObject);
        }
        eventSystemInstance = this;

        DontDestroyOnLoad(gameObject);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
