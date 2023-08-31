using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class M_FlyerMove : M_State
{
    M_Flyer flyer;
    Vector2 route;
    Transform enterPosition;
    Transform currentPosition;
    public float x;
    float routeLength;

    public M_FlyerMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Flyer flyer) : base(@base, stateMachine, aniboolname)
    {
        this.flyer = flyer;
    }

    public override void Enter()
    {
        base.Enter();
        x = 0;
        
        enterPosition = flyer.transform;
        flyer.enterVec = enterPosition.position;
        currentPosition = flyer.GetComponent<Transform>();
        routeLength = flyer.vectorLength(enterPosition.position, flyer.path) + flyer.vectorLength(flyer.path, flyer.moveLocation);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        flyer.curve = route;
        flyer.myposition = flyer.transform.position;

        if ( x < 1)
        {

            route = flyer.Curve(enterPosition.position, flyer.path, flyer.moveLocation, flyer.x) ; // path는 hide에서 정의

            currentPosition.position = route;
            

            flyer.x = x;
            x = x + ( flyer.moveSpeed.x / routeLength) * Time.deltaTime;

        }

        if (x >=1)
        {
            stateMachine.ChangeState(flyer.appear);
            x = 0;
            flyer.x = x;
        }

        flyer.curve = route;
    }
}
