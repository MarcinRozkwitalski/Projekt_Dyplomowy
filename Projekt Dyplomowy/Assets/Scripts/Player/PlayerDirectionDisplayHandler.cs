using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionDisplayHandler : MonoBehaviour
{
    Vector2 CurrentPosition, NewPosition, PlayerDirection, NormalizedPlayerDirection;
    Vector3 CurrentPlayerRotation;
    float x_dir, y_dir;
    public GameObject Player, PlayerFront, PlayerFrontLeft45, PlayerSideLeft, PlayerBackLeft45, PlayerBack;

    public Animator PlayerFrontAnim, PlayerFrontLeft45Anim, PlayerSideLeftAnim, PlayerBackLeft45Anim, PlayerBackAnim;
    public AnimationClip clip;
    Collider2D collider2d;
    public static bool activeAnimationForPlayerPathFollower = false;
    public void HideAllPlayerPerspectives()
    {
        PlayerFront.SetActive(false);
        PlayerFrontLeft45.SetActive(false);
        PlayerSideLeft.SetActive(false);
        PlayerBackLeft45.SetActive(false);
        PlayerBack.SetActive(false);
    }
    public void DisablePLayersCollider()
    {
        collider2d.enabled = false;
    }

    public void EnablePLayersCollider()
    {
        collider2d.enabled = true;
    }

    public void ShowPlayerFront()
    {
        PlayerFront.SetActive(true);
    }
    /// FILIP START IDEA STWORZENIA GLOBALNEGO ANIMATIONCLIP[] ze wszystkimi klipami WYCIĄGANIE ANIMACJI I ANIMATORÓW W PĘTLI
    public float AnimationLength()
    {
        float playerFrontJumpTime = 0.0f;
        AnimationClip[] clips = PlayerFrontAnim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "PlayerFrontJump":
                    playerFrontJumpTime = clip.length;
                    break;
            }
        }
        return playerFrontJumpTime;
    }
    public void StopAnimations()
    {
        PlayerFrontAnim.SetBool("is1True", false);
        PlayerFrontAnim.SetBool("is1False", false);
    }

    public void PlayerSetDeafultPosition()
    {
        gameObject.transform.position = new Vector3(0, -4, 0);
    }
    //// FILIP END

    void Start()
    {
        HideAllPlayerPerspectives();
        PlayerFront.SetActive(true);

        PlayerFrontAnim = PlayerFront.GetComponent<Animator>(); // Filip
        PlayerFrontLeft45Anim = PlayerFrontLeft45.GetComponent<Animator>(); // Filip
        PlayerBackLeft45Anim = PlayerBackLeft45.GetComponent<Animator>(); // Filip
        PlayerSideLeftAnim = PlayerSideLeft.GetComponent<Animator>(); // Filip
        PlayerBackAnim = PlayerBack.GetComponent<Animator>(); // Filip
        collider2d = gameObject.GetComponent<Collider2D>(); // Filip

        // do czas animacji 

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerMovement.canMove == true)
        {
            DisplayProperAnimation();
        }

        // FILIP dodałem warunek by animować chodzenie dla gotowych ścieżek dla PlayerPathFollower
        else if (activeAnimationForPlayerPathFollower)
        {
            DisplayProperAnimation();
            activeAnimationForPlayerPathFollower = false;
        }
    }

    void HandleSpecificCase(GameObject nameOfGameObject, int currentRotation, int finalRotation){
        HideAllPlayerPerspectives();
        nameOfGameObject.SetActive(true);
        RotateGameObject(nameOfGameObject, currentRotation, finalRotation);
    }

    void RotateGameObject(GameObject nameOfGameObject, int currentRotation, int finalRotation){
        if (nameOfGameObject.transform.eulerAngles.y == currentRotation) nameOfGameObject.transform.Rotate(0, finalRotation, 0);
    }

    void DisplayProperAnimation()
    {
        CurrentPosition = transform.position;
        if(activeAnimationForPlayerPathFollower) NewPosition = PlayerPathFollower.playerDestination; //pathfollower
        else NewPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //punkt myszki gracza
        PlayerDirection = (NewPosition - CurrentPosition);
        NormalizedPlayerDirection = PlayerDirection.normalized;
        x_dir = NormalizedPlayerDirection.x;
        y_dir = NormalizedPlayerDirection.y;

        //Up
        if ((-0.5000000f <= x_dir && x_dir <= 0.5000000f) && (0.8660001f <= y_dir && y_dir <= 1.0f)) HandleSpecificCase(PlayerBack, 0, 0);

        //Down
        if ((-0.5000000f <= x_dir && x_dir <= 0.5000000f) && (-1.0f <= y_dir && y_dir <= -0.8660001f)) HandleSpecificCase(PlayerFront, 0, 0);

        //Left-Down
        if ((-0.8660001f <= x_dir) && (x_dir <= -0.4500001f) && (-0.8660001f <= y_dir) && (y_dir <= -0.4500001f)) HandleSpecificCase(PlayerFrontLeft45, 180, -180);

        //Right-Down
        if ((0.4500001f <= x_dir && x_dir <= 0.8660001f) && (-0.8650001f <= y_dir && y_dir <= -0.4500001f)) HandleSpecificCase(PlayerFrontLeft45, 0, 180);

        //Left
        if ((-1.0f <= x_dir && x_dir <= -0.8660001f) && (-0.5000000f <= y_dir && y_dir <= 0.5000000f)) HandleSpecificCase(PlayerSideLeft, 180, -180);

        //Right
        if ((0.8660001f <= x_dir && x_dir <= 1.0f) && (-0.5000000f <= y_dir && y_dir <= 0.5000000f)) HandleSpecificCase(PlayerSideLeft, 0, 180);

        //Left-Up
        if ((-0.8660001f <= x_dir && x_dir <= -0.4500001f) && (0.4500000f <= y_dir && y_dir <= 0.8660001f)) HandleSpecificCase(PlayerBackLeft45, 180, -180);

        //Right-Up
        if ((0.4500000f <= x_dir && x_dir <= 0.8660001f) && (0.4500000f <= y_dir && y_dir <= 0.8660001f)) HandleSpecificCase(PlayerBackLeft45, 0, 180);
    }
}