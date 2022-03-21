using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPathFollower : MonoBehaviour
{
    public static Vector2 playerDestination = new Vector2(1, 1); // w celu blokowania chodzenia dla innych statements
    public Vector2 currentPlayerPosition;
    public static bool playerCanChangePosition = false;
    public static int statementPosition = 0;
    Animator playerSideLeftAnim, playerFrontAnim;
    GameObject playerSideLeft, playerFront;

    bool updateWalkingAnimation = true;

    void Start()
    {
        playerSideLeft = GameObject.Find("Player").transform.Find("PlayerSideLeft").gameObject;
        playerSideLeftAnim = playerSideLeft.GetComponent<Animator>();
        playerFront = GameObject.Find("Player").transform.Find("PlayerFront").gameObject;
        playerFrontAnim = playerFront.GetComponent<Animator>();
    }

    void Update()
    {

        if (playerCanChangePosition)
        {
            switch (statementPosition)
            {
                case 0:
                    Statement_0_Active();
                    break;
                case 1:
                    Statement_1_Active();
                    break;
                case 7:
                    Statement_7_Active();
                    break;
                case 701:
                    Statement_701_Active();
                    break;
                case 702:
                    Statement_702_Active();
                    break;
                case 703:
                    Statement_703_Active();
                    break;
                case 18:
                    Statement_18_Active();
                    break;
                case 1801:
                    Statement_1801_Active();
                    break;
                case 23:
                    Statement_23_Active();
                    break;
                case 2301:
                    Statement_2301_Active();
                    break;
                case 91:
                    Statement_91_Active();
                    break;
                case 92:
                    Statement_92_Active();
                    break;
                default:
                    break;

            }
        }

        if (playerDestination == currentPlayerPosition)
        {
            updateWalkingAnimation = true;
            playerCanChangePosition = false;
            if (statementPosition == 91 ||
            statementPosition == 7 || statementPosition == 701 || statementPosition == 702 || statementPosition == 703
            ) PlayerMovement.canMove = false;
            else PlayerMovement.canMove = true;
            playerDestination = new Vector2(1, 1);
        }
    }
    public void Statement_1_Active()
    {
        playerDestination = new Vector2(2, -6);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_0_Active()
    {
        playerDestination = new Vector2(1, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_7_Active()
    {
        playerDestination = new Vector2(-10, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_701_Active()
    {
        playerSideLeftAnim.SetBool("defaultStatement7", true);
        playerDestination = new Vector2(0.40f, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_702_Active()
    {
        playerDestination = new Vector2(1.70f, -4.64f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_703_Active()
    {
        playerDestination = new Vector2(3.64f, -3.4f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_18_Active()
    {
        playerDestination = new Vector2(-10, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_1801_Active()
    {
        playerDestination = new Vector2(-6, -3.76f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_23_Active()
    {
        playerDestination = new Vector2(-10, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_2301_Active()
    {
        playerDestination = new Vector2(-6, -3.76f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Statement_91_Active()
    {
        playerDestination = new Vector2(-10, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }
    public void Statement_92_Active()
    {
        playerDestination = new Vector2(1, -3.72f);
        if (updateWalkingAnimation == true)
        {
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Player_Position_Update()
    {
        currentPlayerPosition = gameObject.transform.position;
        PlayerMovement.lastClickedPos = currentPlayerPosition;
        PlayerMovement.moving = true;
    }

    public void Player_Moving()
    {
        float step = PlayerMovement.walkspeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerDestination, step);
    }


}
