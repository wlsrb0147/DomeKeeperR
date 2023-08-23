using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetEntity : MonoBehaviour
{
    protected Rigidbody2D rbody;
    protected Animator anim;
    protected SpriteRenderer spr;

    [Header("Collision Info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected private float groundCheckDistance;
    //[SerializeField] protected Transform wallCheck;
    //[SerializeField] protected private float wallCheckDistance;
    [SerializeField] protected Transform mineralCheck;
    [SerializeField] protected float mineralCheckDistance;
    [SerializeField] protected Transform mineralSideCheck;
    [SerializeField] protected float mineralSideCheckDistance;
    [SerializeField] protected private LayerMask whatIsGround;
    //[SerializeField] protected private LayerMask whatIsWall;
    [SerializeField] protected private LayerMask WhatIsMineral;
    [SerializeField] protected Transform footPos;
    [SerializeField] protected Transform toothPos;

    protected bool isGrounded;
    //protected bool isWallDetected;
    protected bool isMineraled;
    protected bool isSideMineraled;

    protected int facingDir = -1;
    protected bool facingRight = true;

    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        CollisionChecks();
    }

    protected virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        isMineraled = Physics2D.Raycast(mineralCheck.position, Vector2.down, mineralCheckDistance, WhatIsMineral);
        isSideMineraled = Physics2D.Raycast(mineralCheck.position, Vector2.left, mineralCheckDistance, WhatIsMineral) 
            || Physics2D.Raycast(mineralCheck.position, Vector2.right, mineralCheckDistance, WhatIsMineral);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(mineralCheck.position, new Vector3(mineralCheck.position.x, mineralCheck.position.y - mineralCheckDistance));
        Gizmos.DrawLine(mineralSideCheck.position, new Vector3(mineralSideCheck.position.x + mineralSideCheckDistance * facingDir, mineralSideCheck.position.y));
        Gizmos.DrawLine(mineralSideCheck.position, new Vector3(mineralSideCheck.position.x - mineralSideCheckDistance * facingDir, mineralSideCheck.position.y));
    }
    #region Velocity

    public void ZeroVelocity() => rbody.velocity = Vector2.zero;

    #endregion


}
