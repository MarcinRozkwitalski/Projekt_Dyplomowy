using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaysOfLaunchingTheAnimations : MonoBehaviour
{
    PlayerDirectionDisplayHandler playerDirectionDisplayHandler;
    void Start()
    {
        playerDirectionDisplayHandler = GameObject.Find("Player").GetComponent<PlayerDirectionDisplayHandler>();
    }

    // Using doors for animation
    public IEnumerator DoorAnimations(Animator animator)
    {
        if (TriggerAnimation.runAnimation == true && TriggerAnimation.runAgain == true)
        {
            TriggerAnimation.runAgain = false;
            OpenDoor();
            yield return new WaitForSeconds(1f);
            animator.SetBool("Start", true); // parametr odpalający animacje 
            Debug.Log("Otwórz Drzwi");
        }
        if (TriggerAnimation.runAnimation == false && TriggerAnimation.runAgain == true)
        {
            TriggerAnimation.runAgain = false;
            animator.SetBool("Start", false);
            yield return new WaitForSeconds(1f);
            CloseDoor();
            TriggerAnimation.startTransition = true;
            Debug.Log("Zamnknij Drzwi");
        }
    }

    void OpenDoor()
    {
        DoorHandler.doorStatus = 0;
    }
    void CloseDoor()
    {
        DoorHandler.doorStatus = 1;
    }

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
    }

    // Using Tale Animations
    public IEnumerator TaleAnimation(Animator animator)
    {
        if (TriggerAnimation.startTale == true)
        {
            animator.SetBool("Start", true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("Start", false);
            TriggerAnimation.startTale = false;
            PlayerMovement.canMove = false;
        }
        else
        {
            if (SentenceHandler.hashTableAnswers[AnswerHandler.index] != null)
            {
                if (SentenceHandler.hashTableAnswers[AnswerHandler.index] == "true")
                {
                    // Check if Player has animation yes


                    // else use animation of given index

                }
                else{
                    
                }
            }
        }

    }

    // Methods for TransitionWithPlayer
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
