using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject firstButton;
    private InputManager inputManager;
    public bool isGamePaused;

    private void OnEnable()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.OnPauseTriggered += TogglePauseState;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void OnDisable() {
        inputManager.OnPauseTriggered -= TogglePauseState;
    }

    private void TogglePauseState()
    {
        Debug.Log("Toggled");
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        inputManager.playerInputActions.Player.Enable();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void PauseGame()
    {
        FindObjectOfType<EventSystem>().SetSelectedGameObject(firstButton);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        inputManager.playerInputActions.Player.Disable();
        isGamePaused = true;
    }
    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
