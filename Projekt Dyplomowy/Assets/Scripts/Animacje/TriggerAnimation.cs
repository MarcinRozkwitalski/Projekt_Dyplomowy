using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    void Start()
    {
        if (AnswerHandler.index != int.Parse(gameObject.name))
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
        else
        {
            StartCoroutine(Time());
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().Play(gameObject.name);
    }
}
