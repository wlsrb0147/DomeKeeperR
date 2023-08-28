using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Shifter : M_Holding
{
    public M_ShifterAppear appear { get; private set; }
    public M_ShifterAttack attack { get; private set; }
    public M_ShifterDead dead { get; private set; }
    public M_ShifterHit hit { get; private set; }
    public M_ShifterIdle idle { get; private set; }
    public M_ShifterShift shift { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        appear = new M_ShifterAppear(this, stateMachine, "Appear", this);
        attack = new M_ShifterAttack(this, stateMachine, "Attack", this);
        dead = new M_ShifterDead(this, stateMachine, "Dead", this);
        hit = new M_ShifterHit(this, stateMachine, "Hit", this);
        idle = new M_ShifterIdle(this, stateMachine, "Idle", this);
        shift = new M_ShifterShift(this, stateMachine, "Shift", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(appear);
    }

    protected override void Update()
    {
        base.Update();
    }
}
