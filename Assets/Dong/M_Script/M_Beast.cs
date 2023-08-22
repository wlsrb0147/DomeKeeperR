using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Beast : M_Base
{
    public M_BeastMove beastMove { get; private set; } 
    protected override void Awake()
    {
        base.Awake();
        beastMove = new M_BeastMove(this,stateMachine,"Move",this);

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
