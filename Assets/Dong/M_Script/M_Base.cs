using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Base : MonoBehaviour
{
    public M_StateMachine stateMachine { get; private set; }
    public Animator ani;

    public Transform domeCenter;

    protected virtual void Awake()
    {
        stateMachine = new M_StateMachine();
    }
    
    protected virtual void Start()
    {
       
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }
}
