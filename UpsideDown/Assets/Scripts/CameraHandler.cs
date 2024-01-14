using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] Camera cam_1;
    [SerializeField] Camera cam_2;

    void Awake()
    {
        cam_1.enabled = true;
        if (!(cam_2 == null))
        {
            cam_2.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !(cam_2 == null))
        {
            cam_1.enabled = !cam_1.enabled;
            cam_2.enabled = !cam_2.enabled;
        }
    }
}
