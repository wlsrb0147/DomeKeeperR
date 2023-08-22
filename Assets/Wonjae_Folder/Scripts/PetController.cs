using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PetController : PetEntity
{
    [Header("Pet Info")]
    [SerializeField] private float petSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] bool isMoving;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (isWallDetected)
        {
            Flip();
        }

        if (isGrounded)
        {
            anim.SetBool("Under_Mine", true);

        }
        else
            anim.SetBool("Under_Mine", false);
        

            if (anim != null)
        {
            if (Mathf.Abs(petSpeed) > 0.01f)
            {
                anim.SetBool("PMove", true);
            }
            else
                anim.SetBool("PMove", false);
        }
  

        rbody.velocity = new Vector2(petSpeed * facingDir, rbody.velocity.y);
        
    }



}