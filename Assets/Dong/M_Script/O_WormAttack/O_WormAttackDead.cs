using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_WormAttackDead : M_State
{
    O_WormAttack wormAttack;
    public O_WormAttackDead(M_Base @base, M_StateMachine stateMachine, string aniboolname, O_WormAttack wormAttack) : base(@base, stateMachine, aniboolname)
    {
        this.wormAttack = wormAttack;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
