using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionDisplayHandler : MonoBehaviour
{
    Vector2 CurrentPosition, NewPosition, PlayerDirection, NormalizedPlayerDirection;
    Vector3 CurrentPlayerRotation;
    float x_dir, y_dir;
    public GameObject PlayerSide, PlayerFront;

    public Animator PlayerSideAnim, PlayerFrontAnim;

    void HideAllPlayerSides(){
        PlayerFront.SetActive(false);
        PlayerSide.SetActive(false);
        //Other Sides of Player are needed to be listed here
    }

    void Start()
    {
        PlayerSide.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            CurrentPosition = transform.position;
            NewPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlayerDirection = (NewPosition - CurrentPosition);
            NormalizedPlayerDirection = PlayerDirection.normalized;
            x_dir = NormalizedPlayerDirection.x;
            y_dir = NormalizedPlayerDirection.y;

            //Right
            if (0.8660001f <= x_dir && x_dir <= 1.0f && 
                -0.5000000f <= y_dir && y_dir <= 0.5000000f){
                HideAllPlayerSides();
                PlayerSide.SetActive(true);

                if(PlayerSide.transform.eulerAngles.y == 0) PlayerSide.transform.Rotate(0, 180, 0);

                //Debug.Log("Going Right");
            }

            //Right-Down
             if (0.4500001f <= x_dir && x_dir <= 0.8660001f && 
                -0.8650001f <= y_dir && y_dir <= -0.4500001f){

                //Debug.Log("Going Right-Down");
            
            }
            //Down
            if (-0.5000000f <= x_dir && x_dir <= 0.5000000f && 
                -1.0f <= y_dir && y_dir <= -0.8660001f){
                HideAllPlayerSides();
                PlayerFront.SetActive(true);

                //Debug.Log("Going Down");
            }

            //Left-Down
            if ((-0.8660001f <= x_dir) && (x_dir <= -0.4500001f) && 
                (-0.8660001f <= y_dir) && (y_dir <= -0.4500001f)){
                
                //Debug.Log("Going Left-Down");
            }

            //Left
            if (-1.0f <= x_dir && x_dir <= -0.8660001f && 
                -0.5000000f <= y_dir && y_dir <= 0.5000000f){
                HideAllPlayerSides();
                PlayerSide.SetActive(true);
       
                if(PlayerSide.transform.eulerAngles.y == 180) PlayerSide.transform.Rotate(0, -180, 0);
                
                //Debug.Log("Going Left");
            }

            //Left-Up
            if (-0.8660001f <= x_dir && x_dir <= -0.4500001f && 
                0.4500000f <= y_dir && y_dir <= 0.8660001f){
                
                //Debug.Log("Going Left-Up");
            }

            //Up
            if (-0.5000000f <= x_dir && x_dir <= 0.5000000f && 
                0.8660001f <= y_dir && y_dir <= 1.0f){
                HideAllPlayerSides();
                PlayerFront.SetActive(true);
        
                //Debug.Log("Going Up");
            }

            //Right-Up
            if (0.4500000f <= x_dir && x_dir <= 0.8660001f && 
                0.4500000f <= y_dir && y_dir <= 0.8660001f){
                
                //Debug.Log("Going Right-Up");
            }

            //Debug.DrawLine(CurrentPosition, NewPosition, Color.red, 15.0f);

            //Debug.Log("Direction = " + NormalizedPlayerDirection);
            //Debug.Log("CurrentPosition = " + CurrentPosition);
            //Debug.Log("NewPosition = " + NewPosition);
            //Debug.Log("X equals " + x_dir);
            //Debug.Log("Y equals " + y_dir);
        }
    }
}
