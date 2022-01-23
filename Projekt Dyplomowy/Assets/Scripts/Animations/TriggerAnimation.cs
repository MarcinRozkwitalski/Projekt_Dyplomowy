using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    WaysOfLaunchingTheAnimations waysOfLaunchingTheAnimations;
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    Animator animator;
    public static bool runAnimation = true;
    public static bool runAgain = true;
    public static bool startTransition = true;
    public static bool playAnimation = true;
    public static bool blockPlayerMovement = true;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        waysOfLaunchingTheAnimations = GameObject.Find("AnimationHandler").GetComponent<WaysOfLaunchingTheAnimations>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (PlayerCanInteract.canChangeIndex == true &&
            SentenceHandler.hashTableAnswers.Count == TestScriptForIndex.indexList.Count &&
            PlayerMovement.canMove == true &&
            PlayerCanInteract.playerCanDecide == true &&
            blockPlayerMovement == true)
        {
            AnswerHandler.index = 91;
            PlayerMovement.canMove = false;
        }


        if (AnswerHandler.index != int.Parse(gameObject.name))
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }

        }
        else
        {
            GameObject originalGameObject = GameObject.Find(gameObject.name);
            for (int i = 0; i < originalGameObject.transform.childCount; i++)
            {
                GameObject child = originalGameObject.transform.GetChild(i).gameObject;
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
