using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sources
//https://stackoverflow.com/questions/40752083/how-to-find-child-of-a-gameobject-or-the-script-attached-to-child-gameobject-via

public class TriggerAnimation : MonoBehaviour
{
    WaysOfLaunchingTheAnimations waysOfLaunchingTheAnimations;
    Animator animator;
    public static bool runAnimation = true;
    public static bool runAgain = true;
    public static bool startTransition = true;
    public static bool startTale = true;
    public static bool sentenceAnswered = false; // czy udzielono odpowiedzi na stwierdzenie

    void Start()
    {
        waysOfLaunchingTheAnimations = GameObject.Find("AnimationHandler").GetComponent<WaysOfLaunchingTheAnimations>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //(AnswerHandler.index != int.Parse(gameObject.name))
        //podmienić to na dole :)
        // PlayerCanInteract.index
        if (AnswerHandler.index != int.Parse(gameObject.name))
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            if (originalGameObject.GetComponent<Renderer>().enabled) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

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
            if (originalGameObject.GetComponent<Renderer>().enabled == false) originalGameObject.GetComponent<Renderer>().enabled = !originalGameObject.GetComponent<Renderer>().enabled;

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

        // if (gameObject.tag == "UseDoor")
        // {
        //     StartCoroutine(waysOfLaunchingTheAnimations.DoorAnimations(animator));
        // }

        // // tranzycja wejścia dla animacji gracza po odpowiedzi
        // if (SentenceHandler.hashTableAnswers[1] != null && startTransition == true)
        // {
        //     StartCoroutine(waysOfLaunchingTheAnimations.TransitionWithPlayer());
        // }

        // wejście fabuły bez tranzycji przed odpowiedzią gracza
        // if (gameObject.tag == "Tale")
        // {
            StartCoroutine(waysOfLaunchingTheAnimations.TaleAnimation(animator,gameObject.tag));
        // }
    }
}
