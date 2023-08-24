using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Ticker : M_Moving
{
    public M_TickerDead dead { get; private set; }
    public M_TickerExplosion explosion { get; private set; }
    public M_TickerJump jump { get; private set; }
    public M_TickerMove move { get; private set; }

    public Vector2 jumpPower;


    protected override void Awake()
    {
        base.Awake();
        dead = new M_TickerDead(this, stateMachine, "Dead", this);
        explosion = new M_TickerExplosion(this, stateMachine, "Explosion", this);
        jump = new M_TickerJump(this, stateMachine, "Jump", this);
        move = new M_TickerMove(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        rb.gravityScale = 0;
        stateMachine.Initiate(move);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dome"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            stateMachine.ChangeState(explosion);
        }
    }

    public void DeleteCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
