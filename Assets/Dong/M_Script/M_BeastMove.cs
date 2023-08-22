using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BeastMove : M_State
{
    M_Beast beast;
    public M_BeastMove(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Beast beast) : base(@base, stateMachine, aniboolname)
    {
        this.beast = beast;
    }
}
