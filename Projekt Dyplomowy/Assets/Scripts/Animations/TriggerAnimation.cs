using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sources
//https://stackoverflow.com/questions/40752083/how-to-find-child-of-a-gameobject-or-the-script-attached-to-child-gameobject-via

public class TriggerAnimation : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //(AnswerHandler.index != int.Parse(gameObject.name))
        //podmienić to na dole :)
        if (PlayerCanInteract.index != int.Parse(gameObject.name))
        {      
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            if(originalGameObject.GetComponent<Renderer>().enabled) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject; // dziecko
                //Debug.Log("Rodzic " + originalGameObject.name + " Dziecko " + child.name);
                child.SetActive(false);
            }

        }
        else
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            if(originalGameObject.GetComponent<Renderer>().enabled == false) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject; // dziecko
                //Debug.Log("Rodzic " + originalGameObject.name + " Dziecko " + child.name);
                child.SetActive(true);
            }
            StartCoroutine(Time());
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(0f);
        animator.SetBool("isIndexCorrect", true);
        //GetComponent<Animator>().Play(gameObject.name);
        //PlayerMovement.canMove = false;
    }
}
