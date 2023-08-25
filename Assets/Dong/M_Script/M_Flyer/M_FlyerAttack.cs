using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FlyerAttack : M_State
{
    M_Flyer flyer;
    public M_FlyerAttack(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
    {
        this.flyer = flyer;
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
        /*if (Vector2.Distance(flyer.transform.position, flyer.moveLocation.position) < 1)
        {
            stateMachine.ChangeState(flyer.hide);
        }*/
    }
}
