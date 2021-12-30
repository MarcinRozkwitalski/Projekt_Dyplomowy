using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaysOfLaunchingTheAnimations : MonoBehaviour
{
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    PreparedStatementAnimations preparedStatementAnimations;
    PlayerPathFollower playerPathFollower;
    AnimationTime animationtime;

    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
        playerPathFollower = GameObject.Find("Player").GetComponent<PlayerPathFollower>();
        preparedStatementAnimations = GameObject.Find("AnimationHandler").GetComponent<PreparedStatementAnimations>();
        animationtime = GameObject.Find("AnimationHandler").GetComponent<AnimationTime>();

    }

    public IEnumerator Animation(Animator animator, string tag)
    {
        if (TriggerAnimation.startTale == true && tag != "UseDoor" && tag != "WaitForClick")
        {
            SetActive_False_Object(AnswerHandler.index); // test
            PlayerMovement.canMove = false;
            playerDirectionDisplayHandler.DisablePLayersCollider();
            animator.SetBool("Intro", true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("Intro", false);
            TriggerAnimation.startTale = false;

        }
        else if (tag == "UseDoor" && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
            StartCoroutine(preparedStatementAnimations.OpenDoorAnimation(animator));
        }
        else if (tag == "WaitForClick" && TriggerAnimation.startTale == true && SentenceHandler.hashTableAnswers[AnswerHandler.index] == null)
        {
            if (PlayerMovement.canMove == true)
            {
                PlayerMovement.canMove = false;
                playerDirectionDisplayHandler.DisablePLayersCollider();
                animator.SetBool("Intro", true);
            }
            if (PlayerCanInteract.playerCanClick == false)
            {
                Debug.Log("playerClick = " + PlayerCanInteract.playerCanClick);
                animator.SetBool("Intro", false);
                PlayerCanInteract.playerCanClick = true;
                TriggerAnimation.startTale = false;
            }
        }
        else
        {
            if (SentenceHandler.hashTableAnswers[AnswerHandler.index] != null)
            {
                if (SentenceHandler.hashTableAnswers[AnswerHandler.index].Equals("true"))
                {
                    switch (AnswerHandler.index)
                    {
                        case 1:
                            StartCoroutine(preparedStatementAnimations.CloseDoorAnimation(animator));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_1());
                            break;
                        case 2:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            PlayerCanInteract.canChangeIndex = true;
                            PlayerMovement.canMove = true;
                            PlayerCanInteract.playerCanDecide = true;
                            break;
                        case 3:
                            GameObject.Find("Computer").transform.Find("Computer - Speaker").gameObject.SetActive(true);
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_Yes_3();
                            break;
                        case 4:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_Yes_3();
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_Yes_11());
                            break;
                        default:
                            Debug.Log("Something went wrong with choosing statement animation");
                            break;

                    }
                }
                else
                {
                    switch (AnswerHandler.index)
                    {
                        case 1:
                            StartCoroutine(preparedStatementAnimations.CloseDoorAnimation(animator));
                            StartCoroutine(preparedStatementAnimations.Statement_No_1());
                            break;
                        case 2:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            PlayerCanInteract.canChangeIndex = true;
                            PlayerMovement.canMove = true;
                            PlayerCanInteract.playerCanDecide = true;
                            break;
                        case 3:
                            GameObject.Find("Computer").transform.Find("Computer - Speaker").gameObject.SetActive(true);
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_Yes_3();
                            break;
                        case 4:
                            animator.SetBool("Outro", true);
                            preparedStatementAnimations.Statement_No_Yes_3();
                            break;
                        case 11:
                            animator.SetBool("Outro", true);
                            //yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            StartCoroutine(preparedStatementAnimations.Statement_No_11());
                            break;
                        default:
                            Debug.Log("Something went wrong with choosing statement animation");
                            break;

                    }
                }
            }
            else
            {
            }
        }

    }
    // Wyłączania obiektów 
    public void SetActive_False_Object(int index)
    {
        if (index == 3 && GameObject.Find("Computer - Speaker") != null)
        {
            GameObject.Find("Computer - Speaker").SetActive(false);
        }
    }

}

