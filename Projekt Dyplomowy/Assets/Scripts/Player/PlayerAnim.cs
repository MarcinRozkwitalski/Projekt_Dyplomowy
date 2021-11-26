using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour{

    private Animator anim;
    public Rigidbody2D PlayerRigidbody;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(PlayerMovement.moving == true){
            anim.SetBool("isMoving", true);
        } else {
            anim.SetBool("isMoving", false);
        }
    }
}
