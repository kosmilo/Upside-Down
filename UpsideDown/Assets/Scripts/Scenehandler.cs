using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;

    private void Start()
    {
        if (fadeAnimator == null)
        {
            fadeAnimator = GameObject.FindWithTag("SceneFade").GetComponent<Animator>();
        }
    }

    public void Play()
    {
        StartCoroutine(LoadScene(1));
    }

    public void PreviousScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void NextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadScene(0));
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        fadeAnimator.Play("FadeOut");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(sceneIndex);
    }
}
