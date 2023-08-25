using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FlyerHide : M_State
{
    int x;
    M_Flyer flyer;
    public M_FlyerHide(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
    {
        this.flyer = flyer;
    }

    public override void Enter()
    {
        base.Enter();
        flyer.inactive.enabled = true;

        if(flyer.transform.position.x > 0) { x = -1;}
        else if (flyer.transform.position.x < 0) {x = 1;}

        flyer.moveLocation = new Vector2(Random.Range(2f, 15f)*x, Random.Range(-2f, 5f));
    }

    public override void Exit()
    {
        base.Exit();
        flyer.active.enabled = false;
        flyer.inactive.enabled = false;
    }

    public override void Update()
    {
        base.Update();
    }
}
