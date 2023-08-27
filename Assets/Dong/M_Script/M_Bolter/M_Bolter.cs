using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Bolter : M_Moving
{
    public M_BolterAttack1 attack1 { get; private set; }
    public M_BolterAttack2 attack2 { get; private set; }
    public M_BolterDead dead { get; private set; }
    public M_BolterMove1 move1 { get; private set; }
    public M_BolterMove2 move2 { get; private set; }
    public M_BolterHit hit { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        attack1 = new M_BolterAttack1(this, stateMachine, "Attack1", this);
        attack2 = new M_BolterAttack2(this, stateMachine, "Attack2", this);
        dead = new M_BolterDead(this, stateMachine, "Dead", this);
        move1 = new M_BolterMove1(this, stateMachine, "Move1", this);
        move2 = new M_BolterMove2(this, stateMachine, "Move2", this);
        hit = new M_BolterHit(this, stateMachine, "Hit", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(move1);
        Debug.Log("asd");
    }

    protected override void Update()
    {
        base.Update();
    }
}
