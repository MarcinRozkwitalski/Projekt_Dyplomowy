using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkspeed;
    public Rigidbody2D rb;
    float move;
    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(walkspeed * direction * Time.fixedDeltaTime, rb.velocity.y);
    }
}
