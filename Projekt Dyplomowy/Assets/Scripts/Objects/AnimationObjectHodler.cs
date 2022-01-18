using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationObjectHodler : MonoBehaviour
{
    void Update()
    {
        GameObject originalGameObject = gameObject;
        if (SentenceHandler.hashTableAnswers[int.Parse(gameObject.name)] == null)
        {
            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }

        }
        else if (AnswerHandler.index == int.Parse(gameObject.name) && SentenceHandler.hashTableAnswers[int.Parse(gameObject.name)] != null
        && originalGameObject.transform.childCount > 1)
        {
            if (SentenceHandler.hashTableAnswers[int.Parse(gameObject.name)].Equals("true"))
            {
                GameObject child = originalGameObject.transform.GetChild(0).gameObject;
                child.SetActive(true);
            }
            else if (SentenceHandler.hashTableAnswers[int.Parse(gameObject.name)].Equals("false"))
            {
                GameObject child = originalGameObject.transform.GetChild(1).gameObject;
                child.SetActive(true);
            }
        }
    }
}
