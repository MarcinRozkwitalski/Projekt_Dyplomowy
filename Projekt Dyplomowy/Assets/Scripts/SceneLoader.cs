using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextSentence()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    void Update()
    {
        if (GameTimeHandler.nextSceneLoader)
        {
            GameTimeHandler.nextSceneLoader = false;
            LoadNextSentence();
        }
    }

    /// <summary>
    /// Load the scenes after clicked on a button in the game.
    /// Uses build settings to determine the scene index.
    /// </summary>
    public void LoadStartScene() {StartCoroutine(LoadLevel(0)); }

    public void LoadSentenceScene() {StartCoroutine(LoadLevel(1)); }

    public void LoadLevel1Scene() {StartCoroutine(LoadLevel(2)); }

    public void LoadLoginUserScene() {StartCoroutine(LoadLevel(3)); }

    public void LoadPlayerSceneScene() {StartCoroutine(LoadLevel(4)); }

    public void LoadRegisterScene() {StartCoroutine(LoadLevel(5)); }

    public void LoadStatisticScene() {StartCoroutine(LoadLevel(6)); }
}
