using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPathFollower : MonoBehaviour
{
    public static Vector2 playerDestination = new Vector2(1, 1); // w celu blokowania chodzenia dla innych statements
    public Vector2 currentPlayerPosition;
    public static bool playerCanChangePosition = false;
    public static int statementPosition = 0;

    bool updateWalkingAnimation = true;


    // Nie możemy tu ustawić canMove na true bo gracz będzie mógł sam chodzić po pokoju

    void Update()
    {

        // aktywacja zmiany pozycji gracza 
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
        // wyłaczenie jeśli dotarł do pozycji
        if (playerDestination == currentPlayerPosition)
        {
            // jak się wejdzie w to samo miejsce to nagle ANOMALIA
            updateWalkingAnimation = true;
            playerCanChangePosition = false;
            if(statementPosition == 91)PlayerMovement.canMove = false;
            else PlayerMovement.canMove = true;
            playerDestination = new Vector2(1, 1); // by żaden if nie działał 
            Debug.Log("Koniec path + movement = " + PlayerMovement.canMove);
        }
    }
    public void Statement_1_Active()
    {
        playerDestination = new Vector2(2, -6);
        if (updateWalkingAnimation == true)
        {// Potrzeba zmiennej która raz uruchomi update chodzenia w else if PlayerDirectionDisplayHandler
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
        {// Potrzeba zmiennej która raz uruchomi update chodzenia w else if PlayerDirectionDisplayHandler
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
        {// Potrzeba zmiennej która raz uruchomi update chodzenia w else if PlayerDirectionDisplayHandler
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
        {// Potrzeba zmiennej która raz uruchomi update chodzenia w else if PlayerDirectionDisplayHandler
            PlayerDirectionDisplayHandler.activeAnimationForPlayerPathFollower = true;
            updateWalkingAnimation = false;
        }
        Player_Position_Update();
        Player_Moving();
    }

    public void Player_Position_Update()
    {
        currentPlayerPosition = gameObject.transform.position;
        PlayerMovement.lastClickedPos = currentPlayerPosition; // ustawia nam pozycje lastClickedPos po to by po zakonczeniu przmieszczania nie potrzebnie znowu się nam pozycja zmieniła
        // Debug.Log("current position" + currentPlayerPosition);
        PlayerMovement.moving = true; // zmienna aktywacji animacji chodzenia
    }

    public void Player_Moving()
    {
        float step = PlayerMovement.walkspeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerDestination, step);
    }


}
