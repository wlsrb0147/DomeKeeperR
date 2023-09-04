using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_PlayerUpState : WJ_PlayerState
{
    public WJ_PlayerUpState(WJ_Player _player, WJ_PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        rbody.velocity = new Vector2(rbody.velocity.x, player.jumpForce);

        if(!Input.GetKey(KeyCode.Space))
            stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
