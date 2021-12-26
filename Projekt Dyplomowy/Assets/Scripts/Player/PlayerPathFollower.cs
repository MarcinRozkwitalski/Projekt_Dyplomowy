using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPathFollower : MonoBehaviour
{
    public static Vector2 playerDestination = new Vector2(1,1); // w celu blokowania chodzenia dla innych statements
    public Vector2 currentPlayerPosition;
    public static bool playerCanChangePosition = false;
    public static int statementPosition = 0;




    // Nie możemy tu ustawić canMove na true bo gracz będzie mógł sam chodzić po pokoju

    void Update()
    {

        // aktywacja zmiany pozycji gracza 
        if (playerCanChangePosition)
        {
            Debug.Log("playerCanChangePosition = true");
            switch (statementPosition)
            {
                case 1:
                    Statement_1_Active();
                    break;
                default:
                    break;

            }
        }
        // wyłaczenie jeśli dotarł do pozycji
        if (playerDestination == currentPlayerPosition)
        {
            // jak się wejdzie w to samo miejsce to nagle ANOMALIA
            playerCanChangePosition = false;
            PlayerMovement.canMove = true;
        }
    }
    public void Statement_1_Active()
    {
        playerDestination = new Vector2(2, -6);
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
