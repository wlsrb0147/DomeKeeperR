using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetEntity : MonoBehaviour
{
    protected Rigidbody2D rbody;
    protected Animator anim;
    protected SpriteRenderer spr;

    [Header("Pet Info")]
    [SerializeField] private float petSpeed;
    [SerializeField] private float petDamage;
    [SerializeField] private float mineSpeed;


    [Header("Collision Info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected private float groundCheckDistance;
    [SerializeField] protected Transform mineralUnderCheck;
    [SerializeField] protected float mineralCheckDistance;
    [SerializeField] protected private LayerMask whatIsGround;
    [SerializeField] protected private LayerMask WhatIsMineral;
    [SerializeField] protected Transform footPos;
    [SerializeField] protected Transform toothPos;


    #region anim
    protected bool isGrounded;
    protected bool isMineraled;
    protected bool petMove;
    protected bool underMine;
    protected bool sideMine;
    protected bool petIdle;
    #endregion

    protected int facingDir = -1;
    protected bool facingRight = true;

    S_Mineral mineral;
    bool mineralCheck;

    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        mineral = GetComponent<S_Mineral>();
    }

    protected virtual void Update()
    {
        CollisionChecks();
        PetAnimatorControllers();
    }

    #region Flip 
    protected virtual void Flip()
    {
        facingDir = facingDir* -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if (rbody.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rbody.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    #endregion


    #region CollisionChecks
    protected virtual void CollisionChecks()
    {

        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        isMineraled = Physics2D.Raycast(mineralUnderCheck.position, Vector2.down, mineralCheckDistance, WhatIsMineral);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(mineralUnderCheck.position, new Vector3(mineralUnderCheck.position.x, mineralUnderCheck.position.y - mineralCheckDistance));
    }
    #endregion


    #region Velocity

    public void ZeroVelocity() => rbody.velocity = Vector2.zero;
    public void MoveVelocity() => rbody.velocity = new Vector2(petSpeed * facingDir, rbody.velocity.y);

    #endregion


    //private void petMovement()
    //{
    //   MoveVelocity();
    //}

    private void PetAnimatorControllers()
    {
        //bool isMoving = rbody.velocity.x != 0;
        anim.SetBool("Pet_Move", petMove);
        anim.SetBool("Pet_idle", petIdle);
        anim.SetBool("Under_Mine", underMine);
        anim.SetBool("Side_Mine", sideMine);

    }

    void PetUnderMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !mineralCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(footPos.position);
        }
    }

    void PetSideMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !mineralCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(toothPos.position);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Mineral"))
    //    {
    //        mineralCheck = true;
    //    }
    //    else
    //        mineralCheck = false;
    //}

}
