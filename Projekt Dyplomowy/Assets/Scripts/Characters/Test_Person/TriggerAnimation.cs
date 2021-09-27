using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    
    void Start()
    {
        if(int.Parse(gameObject.name) == 1){
            Debug.Log("To jest animacja 1 ");
        }
        if(AnswerHandler.index % 2 == 0){
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
        else
        {
         StartCoroutine(Time());   
        }
    }
 
    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().Play("TestPersonWalk");
    }
}
