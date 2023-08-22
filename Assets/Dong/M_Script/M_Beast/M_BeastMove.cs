using UnityEngine;

public class M_BeastMove : M_State
{
    Rigidbody2D rb;
    M_Beast beast;
    public M_BeastMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Beast beast) : base(@base, stateMachine, aniboolname)
    {
        this.beast = beast;
    }

    public override void Enter()
    {
        base.Enter();
        rb = beast.rb;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        if (Vector2.Distance(beast.domeCenter.position, beast.transform.position) <= 15 && beast.howl == false)
        {
            beast.SetVelocity(0, 0);
            stateMachine.ChangeState(beast.howling);
        }
        else if (Vector2.Distance(beast.domeCenter.position, beast.transform.position) <= 5)
        {
            
        }

        else beast.SetVelocity(5, 0);



    }
}
