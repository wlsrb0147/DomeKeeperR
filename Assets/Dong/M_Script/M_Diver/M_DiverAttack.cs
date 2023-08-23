using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_DiverAttack : M_State
{
    M_Diver diver;
    Vector2 atk;
    public M_DiverAttack(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Diver diver) : base(@base, stateMachine, aniboolname)
    {
        this.diver = diver;
    }

    Vector2 dir;

    public override void Enter()
    {
        base.Enter();
        
        diver.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        diver.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        diver.gameObject.GetComponent<EdgeCollider2D>().enabled = true;

        diver.isAttacking = 1;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    if (diver.transform.position != null)
        {
           /* if(diver.transform.position.x > diver.domeCenter.transform.position.x)
            {
                atk = new Vector2(-diver.Getdir().x, diver.Getdir().y);
            }
            else */ atk = diver.Getdir();
        atk = atk.normalized;
        diver.SetVelocity(atk.x* diver.movingSpeed, atk.y* diver.movingSpeed);
        }
    }
}
