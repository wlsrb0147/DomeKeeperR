using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Diver : M_Moving
{
    public M_DiverAttack attack { get; private set; }
    public M_DiverAttackSuccess attackSuccess { get; private set; }
    public M_DiverAttackDead attackDead { get; private set; }
    public M_DiverBack back { get; private set; }
    public M_DiverBackDead1 backDead1 { get; private set; }
    public M_DiverBackDead2 backDead2 { get; private set; }
    

    protected override void Awake()
    {
        base.Awake();
        attack = new M_DiverAttack(this, stateMachine, "Attack", this);
        attackSuccess = new M_DiverAttackSuccess(this, stateMachine, "AttackSuccess", this);
        attackDead = new M_DiverAttackDead(this, stateMachine, "AttackDead", this);
        back = new M_DiverBack(this, stateMachine, "Back", this);
        backDead1 = new M_DiverBackDead1(this, stateMachine, "BackDead1", this);
        backDead2 = new M_DiverBackDead2(this, stateMachine, "BackDead2", this);
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
}
