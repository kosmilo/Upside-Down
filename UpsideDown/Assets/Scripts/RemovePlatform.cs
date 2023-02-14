using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.name == "Player" || collision.name == "MovableCube")
        {
            platform.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        platform.SetActive(true);
    }
}

