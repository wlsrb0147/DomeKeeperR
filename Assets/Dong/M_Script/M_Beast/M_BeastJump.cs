using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BeastJump : M_State
{
    M_Beast beast;
    public M_BeastJump(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Beast beast) : base(@base, stateMachine, aniboolname)
    {
        this.beast = beast;
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
