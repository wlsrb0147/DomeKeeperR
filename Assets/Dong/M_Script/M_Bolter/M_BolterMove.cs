using UnityEngine;

public class M_BolterMove : M_State
{
    M_Bolter bolter;
    public M_BolterMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Bolter bolter) : base(@base, stateMachine, aniboolname)
    {
        this.bolter = bolter;
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
        if (Vector2.Distance(bolter.domeCenter.position, bolter.transform.position) > 15)
        {
            bolter.SetVelocity(bolter.moveSpeed);
        }
        else
            bolter.SetVelocity(new Vector2(bolter.moveSpeed.x / 1.5f, bolter.moveSpeed.y));

        if (Vector2.Distance(bolter.domeCenter.position, bolter.transform.position) <= 10)
        {
            stateMachine.ChangeState(bolter.attack1);

        }
    }



}
