using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    void Start()
    {
        if (AnswerHandler.index != int.Parse(gameObject.name))
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled; // nie rederuje animacji
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            //https://stackoverflow.com/questions/40752083/how-to-find-child-of-a-gameobject-or-the-script-attached-to-child-gameobject-via
            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject; // dziecko
               // Debug.Log("Rodzic " + originalGameObject.name + " Dziecko " + child.name);
                child.SetActive(false); // dzieki marcin 
            }

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
