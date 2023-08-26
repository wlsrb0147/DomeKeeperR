using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FlyerMove : M_State
{
    M_Flyer flyer;
    Transform pos;
    public M_FlyerMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
    {
        this.flyer = flyer;
    }

    public override void Enter()
    {
        base.Enter();
        pos.position = new Vector3(flyer.path.x, flyer.path.y, 0);
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
            Mathf.Lerp(flyer.transform.position.x, vec.x, flyer.transform.position.x/ vec.x);
            Mathf.Lerp(flyer.transform.position.y, vec.y, flyer.transform.position.y/ vec.y);




            // flyer.transform.Translate(vec*Time.deltaTime*5);
        }

        if (Vector2.Distance(flyer.transform.position, flyer.moveLocation) < 1)
        {
            stateMachine.ChangeState(flyer.appear);
        }
    }
}
