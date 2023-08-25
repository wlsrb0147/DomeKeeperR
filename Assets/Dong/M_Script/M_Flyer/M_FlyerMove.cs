using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FlyerMove : M_State
{
    M_Flyer flyer;
    public M_FlyerMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
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

        if( Vector2.Distance(flyer.transform.position,flyer.moveLocation) > 1)
        {
            Vector2 vec = flyer.FlyerMove();
            flyer.transform.Translate(vec*Time.deltaTime*5);
        }

        if (Vector2.Distance(flyer.transform.position, flyer.moveLocation) < 1)
        {
            stateMachine.ChangeState(flyer.appear);
        }
    }
}
