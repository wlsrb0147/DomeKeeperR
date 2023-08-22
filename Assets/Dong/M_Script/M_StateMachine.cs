using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_StateMachine
{
    public M_State currentState { get; private set; }
    
    
    protected virtual void Initiate(M_State changeState)
    {
        currentState = changeState;
        currentState.Enter();
    }

    protected virtual void ChangeState(M_State changeState)
    {
        currentState.Exit();
        currentState = changeState;
        currentState.Enter();
    }
}
