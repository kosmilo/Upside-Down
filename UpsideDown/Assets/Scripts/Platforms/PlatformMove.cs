using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlatformMove : Platform
{
    [SerializeField] GameObject platform;

    private void OnEnable()
    {
        OnActivate += DisablePlatform;
        OnDeactivate += EnablePlatform;
    }

    private void OnDisable()
    {
        OnActivate -= DisablePlatform;
        OnDeactivate -= EnablePlatform;
    }

    private void DisablePlatform(GameObject obj)
    {
        platform.SetActive(false);
    }

    private void EnablePlatform(GameObject obj)
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, gameObject.GetComponent<BoxCollider2D>().bounds.size, 0f, Vector2.up, 0.05f);

        platform.SetActive(true);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<PlatfomActivator>() != null)
            {
                platform.SetActive(false);
                return;
            }
        }
    }
}

