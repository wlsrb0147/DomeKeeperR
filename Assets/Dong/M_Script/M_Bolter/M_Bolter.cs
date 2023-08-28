using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Bolter : M_Moving
{
    public M_BolterAttack1 attack1 { get; private set; }
    public M_BolterAttack2 attack2 { get; private set; }
    public M_BolterDead dead { get; private set; }
    public M_BolterMove move { get; private set; }
    public M_BolterIdle idle { get; private set; }
    public M_BolterHit hit { get; private set; }

    public float attackCounter;
    public float attackCount { get; set; }

    public int attackChange { get; set; }

    protected override void Awake()
    {
        base.Awake();

        attack1 = new M_BolterAttack1(this, stateMachine, "Attack1", this);
        attack2 = new M_BolterAttack2(this, stateMachine, "Attack2", this);
        dead = new M_BolterDead(this, stateMachine, "Dead", this);
        move = new M_BolterMove(this, stateMachine, "Move", this);
        idle = new M_BolterIdle(this, stateMachine, "Idle", this);
        hit = new M_BolterHit(this, stateMachine, "Hit", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(move);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.F))
        {
            stateMachine.ChangeState(dead);
        }

    }


    public void AttackChange()
    {
        if (stateMachine.currentState != attack2)
        {
            if (attackChange == 2)
            {
                stateMachine.ChangeState(attack2);
            }
        }
    }

    public void EndAttack()
    {
        stateMachine.ChangeState(idle);
    }

}
