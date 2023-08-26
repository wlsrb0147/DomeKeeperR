using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Worm : M_Holding
{
    public M_WormAttack attack { get; private set; }
    public M_WormDead dead { get; private set; }
    public M_WormHide hide { get; private set; }
    public M_WormHit hit { get; private set; }
    public M_WormIdle idle { get; private set; }
    public M_WormInstantiate instantiate { get; private set; }
    public M_WormWakeUp wakeUp { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        attack = new M_WormAttack(this, stateMachine, "Attack", this);
        dead = new M_WormDead(this, stateMachine, "Dead", this);
        hide = new M_WormHide(this, stateMachine, "Hide", this);
        hit = new M_WormHit(this, stateMachine, "Hit", this);
        idle = new M_WormIdle(this, stateMachine, "Idle", this);
        instantiate = new M_WormInstantiate(this, stateMachine, "Instantiate", this);
        wakeUp = new M_WormWakeUp(this, stateMachine, "WakeUp", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(instantiate);
    }

    protected override void Update()
    {
        base.Update();
    }
}
