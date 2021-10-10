using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObjectHodler : MonoBehaviour
{
    void Start()
    {
        if(SentenceHandler.hashTableAnswers[int.Parse(gameObject.name)] == null){
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
    }
}
