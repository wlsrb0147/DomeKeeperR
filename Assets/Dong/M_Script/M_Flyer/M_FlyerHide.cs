using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class M_FlyerHide : M_State
{
    int x;
    M_Flyer flyer;
    int multy;
    public M_FlyerHide(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
    {
        this.flyer = flyer;
    }

    public override void Enter()
    {
        base.Enter();
        flyer.inactive.enabled = true;
        flyer.active.enabled = false;

        if (flyer.transform.position.x > 0) { x = -1;}
        else if (flyer.transform.position.x < 0) {x = 1;}

        flyer.moveLocation = new Vector2(Random.Range(2f, 15f)*x, Random.Range(-2f, 5f));

        flyer.normalVec = new Vector2(flyer.transform.position.y- flyer.moveLocation.y, flyer.moveLocation.x - flyer.transform.position.x);
        flyer.normalVec = flyer.normalVec / 2;
        flyer.centerVec = new Vector2(flyer.moveLocation.x + flyer.transform.position.x, flyer.moveLocation.y + flyer.transform.position.y) / 2;


        multy = (int)((Random.Range(1, 3) - 1.5f)*2);

        flyer.path = new Vector2(flyer.centerVec.x + flyer.normalVec.x*multy , flyer.centerVec.y + flyer.normalVec.y * multy);
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
