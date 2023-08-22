using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PetController : PetEntity
{
    [Header("Pet Info")]
    [SerializeField] private float petSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] float P_attack;
    [SerializeField] bool isMoving;

    S_Mineral mineral;


    protected override void Start()
    {
        base.Start();

        mineral = GetComponent<S_Mineral>();
    }

    protected override void Update()
    {
        base.Update();

        if (isGrounded || isMineraled)
        {
            ZeroVelocity();
            anim.SetBool("Under_Mine", true);
            Debug.Log("땅 파는중!");

        }
        else
            anim.SetBool("Under_Mine", false);

        if (isWallDetected)
        {
            Flip();
        }

       #region #움직임

        //if (anim != null)
        //{
        //    if (Mathf.Abs(petSpeed) > 0.01f)
        //    {
        //        anim.SetBool("PMove", true);
        //    }
        //    else
        //        anim.SetBool("PMove", false);
        //}

        //rbody.velocity = new Vector2(petSpeed * facingDir, rbody.velocity.y);

        #endregion

    }

    void PetMine() 
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(footPos.position, 0.4f, whatIsGround);
        Collider2D mineralCollider = Physics2D.OverlapCircle(footPos.position, 0.4f, WhatIsMineral);

        if (groundCollider != null)
        {
            groundCollider.transform.GetComponent<S_MapGenerator>().MakeDot(footPos.position);
        }
        else if (mineralCollider != null)
        {
            mineralCollider.transform.GetComponent<S_Mineral>().SetDamage(P_attack);
        }

    }


}