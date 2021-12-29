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


    // Using Tale Animations
    public IEnumerator Animation(Animator animator, string tag)
    {
        // odpalenie animacji wybory 
        if (TriggerAnimation.startTale == true && tag != "UseDoor")
        {
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
        // Złapanie wyboru i dopalenie poprawnej animacji(+ może gre)
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
                            break;
                        case 2:
                            animator.SetBool("Outro", true);
                            yield return new WaitForSeconds(animationtime.GetAnimationTimeFromName(animator, "Outro"));
                            PlayerCanInteract.canChangeIndex = true;
                            PlayerMovement.canMove = true;
                            PlayerCanInteract.playerCanDecide = true;
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
                Debug.Log("No answer");
            }
        }

    }


    // Using doors for animation -> przeniesienie do PreparedAnimations 


}
