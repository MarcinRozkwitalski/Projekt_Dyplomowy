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
    public IEnumerator TaleAnimation(Animator animator, string tag)
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
            StartCoroutine(DoorAnimations(animator));
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

    // Using StatementOnly for animation




    // Using doors for animation -> przeniesienie do PreparedAnimations 
    public IEnumerator DoorAnimations(Animator animator)
    {
        if (TriggerAnimation.runAnimation == true && TriggerAnimation.runAgain == true)
        {
            //// zrobić z tego metodę i uruchamiać względem konkretnego indexu przy pomocy switch
            PlayerPathFollower.statementPosition = 1; // wybór statement
            PlayerPathFollower.playerCanChangePosition = true; // podążanie po wyznaczonej ścieżce
            PlayerMovement.canMove = false; // wyłączenie chodzenia gracza
            ////

            TriggerAnimation.runAgain = false;
            DoorHandler.doorStatus = 0;
            yield return new WaitForSeconds(1f);
            animator.SetBool("Start", true); // parametr odpalający animacje 
            Debug.Log("Otwórz Drzwi");
        }
        if (TriggerAnimation.runAnimation == false && TriggerAnimation.runAgain == true)
        {
            TriggerAnimation.runAgain = false;
            animator.SetBool("Start", false);
            yield return new WaitForSeconds(1f);
            DoorHandler.doorStatus = 1;
            TriggerAnimation.startTransition = true;
            Debug.Log("Zamnknij Drzwi");
        }
    }

    // Methods for TransitionWithPlayer -> preparedStatement
    // Using Transitions for player animation

    public IEnumerator TransitionWithPlayer()
    {
        TransitionStart();
        yield return new WaitForSeconds(2.4f);
        PlayerMovement.canMove = false;

        PlayerPlayAnimation();
        PlayerSetDeafultPosition();
        yield return new WaitForSeconds(PlayerAnimationTime() - 2);

        TransitionEnd();
        yield return new WaitForSeconds(2f);
        PlayerStopAnimations();
        Debug.Log("Skończone");
        PlayerMovement.canMove = true; // skrypt zajmujący się czasem tranzycji po której można przywrócić postać do ruchu
        PlayerCanInteract.canChangeIndex = true;
        PlayerCanInteract.playerCanDecide = true;
    }



    void TransitionStart()
    {
        Debug.Log("Start tranzycji");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunRight", true);
        TriggerAnimation.startTransition = false;
    }

    void TransitionEnd()
    {
        Debug.Log("Koniec tranzycji");
        GameObject square = GameObject.Find("Square");
        Animator squareAnimator = square.GetComponent<Animator>();
        squareAnimator.SetBool("RunLeft", true);
        squareAnimator.SetBool("RunRight", false);
    }
    void PlayerPlayAnimation()
    {
        GameObject player = GameObject.Find("Player");
        playerDirectionDisplayHandler.HideAllPlayerPerspectives();
        playerDirectionDisplayHandler.ShowPlayerFront();
        GameObject playerFront = GameObject.Find("PlayerFront");
        Animator playerFrontAnimator = playerFront.GetComponent<Animator>();
        playerFrontAnimator.SetBool("is" + AnswerHandler.index.ToString() + "True", true);
    }

    void PlayerStopAnimations()
    {
        playerDirectionDisplayHandler.StopAnimations();
    }
    void PlayerSetDeafultPosition()
    {
        playerDirectionDisplayHandler.PlayerSetDeafultPosition();
    }

    float PlayerAnimationTime()
    {
        return playerDirectionDisplayHandler.AnimationLength();
    }
}
