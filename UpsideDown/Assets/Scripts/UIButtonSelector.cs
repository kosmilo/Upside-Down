using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIButtonSelector : MonoBehaviour
{
    [SerializeField] public GameObject firstButton;

    void Start()
    {
        FindObjectOfType<EventSystem>().SetSelectedGameObject(firstButton);
    }
}
