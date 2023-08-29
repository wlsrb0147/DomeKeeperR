using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_BolterAttack2 : M_Holding
{
    public O_BolterAttack2Attack attack2 { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        attack2 = new O_BolterAttack2Attack(this, stateMachine, "Attack2");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(attack2);
    }

    protected override void Update()
    {
        base.Update();
    }
}
