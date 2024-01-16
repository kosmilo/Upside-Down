using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGravitySwitcher : Platform
{
    private void OnEnable()
    {
        OnActivate += GravitySwitch;
    }

    private void OnDisable()
    {
        OnActivate -= GravitySwitch;
    }

    public void GravitySwitch(GameObject obj)
    {
        Rigidbody2D rb;
        if (obj.TryGetComponent<Rigidbody2D>(out rb))
        {
            rb.gravityScale *= -1;
        }
    }
}
