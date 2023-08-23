using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Beast : M_Moving
{
    public M_BeastMove move { get; private set; } 
    public M_BeastAttack attack { get; private set; }
    public M_BeastGroundDead groundDead { get; private set; }
    public M_BeastHowling howling { get; private set; }
    public M_BeastJump jump { get; private set; }
    public M_BeastWallDead wallDead { get; private set; }

    public bool howl = false;

    public Rigidbody2D rb;

    protected override void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Awake();

        ani = GetComponent<Animator>();

        move = new M_BeastMove(this,stateMachine,"Move",this);
        attack = new M_BeastAttack(this, stateMachine, "Attack", this);
        groundDead = new M_BeastGroundDead(this, stateMachine, "GroundDead", this);
        howling = new M_BeastHowling(this, stateMachine, "Howling", this);
        jump = new M_BeastJump(this, stateMachine, "Jump", this);
        wallDead = new M_BeastWallDead(this, stateMachine, "WallDead", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(move);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void HowlOn()
    {
        howl = true;
        stateMachine.ChangeState(move);
        Debug.Log("aa");
    }

    public void SetVelocity(float InputX, float InputY)
    {
        rb.velocity = new Vector2(InputX, InputY);
    }


}
