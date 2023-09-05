using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class O_BolterAttack : M_Moving
{
    public O_BolterAttackAttack attack { get; private set; }  
    public O_BolterAttackHit hit { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        attack = new O_BolterAttackAttack(this, stateMachine, "Attack", this);
        hit = new O_BolterAttackHit(this, stateMachine, "Hit", this);
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

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Dome"))
        {
            stateMachine.ChangeState(hit);
        }
    }
}
