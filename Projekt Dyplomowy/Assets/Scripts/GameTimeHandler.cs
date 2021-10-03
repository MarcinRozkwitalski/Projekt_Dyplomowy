using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeHandler : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public static bool nextSceneLoader = false;
    void Start()
    {
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("NUMBER  = " + SentenceHandler.hashTableAnswers.Count);
        if(SentenceHandler.hashTableAnswers.Count == 3){
            sceneLoader.LoadRegister();
        }
        nextSceneLoader = true;
       // Debug.Log("End");
    }

}
