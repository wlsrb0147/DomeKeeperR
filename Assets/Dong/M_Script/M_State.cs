using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class M_State 
{
    protected M_Base m_base;
    protected M_StateMachine stateMachine;
    string aniBoolName;


    public M_State(M_Base @base, M_StateMachine stateMachine,string aniboolname)
    {
        this.m_base = @base;
        this.stateMachine = stateMachine;
        this.aniBoolName = aniboolname;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter" + aniBoolName);
        m_base.ani.SetBool(aniBoolName, true);
    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {
        Debug.Log("Exit" + aniBoolName);
        m_base.ani.SetBool(aniBoolName,false);
    }
}
