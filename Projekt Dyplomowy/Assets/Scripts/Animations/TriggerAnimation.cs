using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//sources
//https://stackoverflow.com/questions/40752083/how-to-find-child-of-a-gameobject-or-the-script-attached-to-child-gameobject-via

public class TriggerAnimation : MonoBehaviour
{
    WaysOfLaunchingTheAnimations waysOfLaunchingTheAnimations;
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    Animator animator;
    public static bool runAnimation = true;
    public static bool runAgain = true;
    public static bool startTransition = true;
    public static bool playAnimation = true;
    public static bool blockAnimation = false;
    public static bool something = true;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        waysOfLaunchingTheAnimations = GameObject.Find("AnimationHandler").GetComponent<WaysOfLaunchingTheAnimations>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (PlayerCanInteract.canChangeIndex == true &&
            SentenceHandler.hashTableAnswers.Count == TestScrpitForIndex.indexList.Count &&
            PlayerMovement.canMove == true &&
            PlayerCanInteract.playerCanDecide == true &&
            something == true)
        {
            playerDirectionDisplayHandler.DisablePLayersCollider();
            AnswerHandler.index = 91;
            PlayerMovement.canMove = false;
            Debug.Log("koniec");
        }


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
        if (AnswerHandler.index == 0 && AnswerHandler.index == int.Parse(gameObject.name)) StartCoroutine(waysOfLaunchingTheAnimations.StartGame());
        else if (AnswerHandler.index == 91 && AnswerHandler.index == int.Parse(gameObject.name)) StartCoroutine(waysOfLaunchingTheAnimations.EndGame());
        else if (AnswerHandler.index != 0 && AnswerHandler.index != 91 && AnswerHandler.index == int.Parse(gameObject.name)) StartCoroutine(waysOfLaunchingTheAnimations.Animation(animator, gameObject.tag));

    }
}
