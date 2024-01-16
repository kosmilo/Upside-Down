using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected event Action<GameObject> OnActivate;
    protected event Action<GameObject> OnDeactivate;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlatfomActivator>() != null)
        {
            Debug.Log("Platform activated");
            OnActivate?.Invoke(collision.gameObject);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" || collision.name == "MovableCube")
        {
            OnDeactivate?.Invoke(collision.gameObject);
        }
    }
}
