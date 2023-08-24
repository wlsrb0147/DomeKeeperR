using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_DiverBackDead1 : M_State
{
    M_Diver diver;
    public M_DiverBackDead1(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Diver diver) : base(@base, stateMachine, aniboolname)
    {
        this.diver = diver;
    }

    public override void Enter()
    {
        base.Enter(); 
        diver.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        diver.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        diver.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        diver.SetVelocity(0, 0);
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
