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

    protected override void Awake()
    {
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
}
