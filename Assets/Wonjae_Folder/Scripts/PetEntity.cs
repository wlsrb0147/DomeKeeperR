using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetEntity : MonoBehaviour
{
    protected Rigidbody2D rbody;
    protected Animator anim;
    protected SpriteRenderer spr;

    [Header("Collision Info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected private float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected private float wallCheckDistance;
    [SerializeField] protected private LayerMask whatIsGround;
    [SerializeField] protected private LayerMask whatIsWall;

    protected bool isGrounded;
    protected bool isWallDetected;

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
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsWall);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }

}
