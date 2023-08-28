using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_WormAttackHit : M_State
{
    O_WormAttack wormAttack;
    public O_WormAttackHit(M_Base @base, M_StateMachine stateMachine, string aniboolname, O_WormAttack wormAttack) : base(@base, stateMachine, aniboolname)
    {
        this.wormAttack = wormAttack;
    }

    public override void Enter()
    {
        base.Enter();
        wormAttack.rb.bodyType = RigidbodyType2D.Static;
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
