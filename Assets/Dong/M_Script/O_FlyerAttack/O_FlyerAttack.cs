using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_FlyerAttack : M_Moving
{
    public O_FlyerAttackAttack attack { get; private set; }
    public O_FlyerAttackHit hit { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        attack = new O_FlyerAttackAttack(this, stateMachine, "Attack", this);
        hit = new O_FlyerAttackHit(this, stateMachine, "Hit", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(attack);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dome"))
        {
            stateMachine.ChangeState(hit);
        }
    }
}
