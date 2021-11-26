using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionDisplayHandler : MonoBehaviour
{
    Vector2 CurrentPosition, NewPosition, PlayerDirection, NormalizedPlayerDirection;
    Vector3 CurrentPlayerRotation;
    float x_dir, y_dir;
    public GameObject PlayerFront, PlayerFrontLeft45, PlayerSideLeft, PlayerBackLeft45, PlayerBack;

    public Animator PlayerFrontAnim, PlayerFrontLeft45Anim, PlayerSideLeftAnim, PlayerBackLeft45Anim, PlayerBackAnim;

    void HideAllPlayerPerspectives(){
        PlayerFront.SetActive(false);
        PlayerFrontLeft45.SetActive(false);
        PlayerSideLeft.SetActive(false);
        PlayerBackLeft45.SetActive(false);
        PlayerBack.SetActive(false);
    }

    void Start()
    {
        HideAllPlayerPerspectives();
        PlayerFront.SetActive(true);
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

            //Down
            if (-0.5000000f <= x_dir && x_dir <= 0.5000000f && 
                -1.0f <= y_dir && y_dir <= -0.8660001f){
                HideAllPlayerPerspectives();
                PlayerFront.SetActive(true);

                //Debug.Log("Going Down");
            }

            //Left-Down
            if ((-0.8660001f <= x_dir) && (x_dir <= -0.4500001f) && 
                (-0.8660001f <= y_dir) && (y_dir <= -0.4500001f)){
                HideAllPlayerPerspectives();
                PlayerFrontLeft45.SetActive(true);

                if(PlayerFrontLeft45.transform.eulerAngles.y == 180) PlayerFrontLeft45.transform.Rotate(0, -180, 0);
                
                //Debug.Log("Going Left-Down");
            }

            //Right-Down
             if (0.4500001f <= x_dir && x_dir <= 0.8660001f && 
                -0.8650001f <= y_dir && y_dir <= -0.4500001f){
                HideAllPlayerPerspectives();
                PlayerFrontLeft45.SetActive(true);

                if(PlayerFrontLeft45.transform.eulerAngles.y == 0) PlayerFrontLeft45.transform.Rotate(0, 180, 0);

                //Debug.Log("Going Right-Down");
            
            }   

            //Left
            if (-1.0f <= x_dir && x_dir <= -0.8660001f && 
                -0.5000000f <= y_dir && y_dir <= 0.5000000f){
                HideAllPlayerPerspectives();
                PlayerSideLeft.SetActive(true);
       
                if(PlayerSideLeft.transform.eulerAngles.y == 180) PlayerSideLeft.transform.Rotate(0, -180, 0);
                
                //Debug.Log("Going Left");
            }

            //Right
            if (0.8660001f <= x_dir && x_dir <= 1.0f && 
                -0.5000000f <= y_dir && y_dir <= 0.5000000f){
                HideAllPlayerPerspectives();
                PlayerSideLeft.SetActive(true);

                if(PlayerSideLeft.transform.eulerAngles.y == 0) PlayerSideLeft.transform.Rotate(0, 180, 0);

                //Debug.Log("Going Right");
            }

            //Left-Up
            if (-0.8660001f <= x_dir && x_dir <= -0.4500001f && 
                0.4500000f <= y_dir && y_dir <= 0.8660001f){
                HideAllPlayerPerspectives();
                PlayerBackLeft45.SetActive(true);

                if(PlayerBackLeft45.transform.eulerAngles.y == 180) PlayerBackLeft45.transform.Rotate(0, -180, 0);
                
                //Debug.Log("Going Left-Up");
            }

            //Right-Up
            if (0.4500000f <= x_dir && x_dir <= 0.8660001f && 
                0.4500000f <= y_dir && y_dir <= 0.8660001f){
                HideAllPlayerPerspectives();
                PlayerBackLeft45.SetActive(true);

                if(PlayerBackLeft45.transform.eulerAngles.y == 0) PlayerBackLeft45.transform.Rotate(0, 180, 0);
                
                //Debug.Log("Going Right-Up");
            }

            //Up
            if (-0.5000000f <= x_dir && x_dir <= 0.5000000f && 
                0.8660001f <= y_dir && y_dir <= 1.0f){
                HideAllPlayerPerspectives();
                PlayerBack.SetActive(true);
        
                //Debug.Log("Going Up");
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
