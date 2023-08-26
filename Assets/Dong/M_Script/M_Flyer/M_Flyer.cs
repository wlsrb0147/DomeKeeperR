using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Flyer : M_Moving
{
    public Collider2D active; // attack,hit때의 collider
    public Collider2D inactive; // apper,hide때의 collider

    public M_FlyerAppear appear {  get; private set; }
    public M_FlyerAttack attack { get; private set; }
    public M_FlyerDead dead { get; private set; }
    public M_FlyerHide hide { get; private set; }
    public M_FlyerHit hit { get; private set; }
    public M_FlyerMove move { get; private set; }

    public Vector2 moveLocation;
    public Vector2 flyerVec;
    public int attackTimes;
    public int currentAttackTimes;

    protected override void Awake()
    {
        base.Awake();
        appear = new M_FlyerAppear(this, stateMachine, "Appear", this);
        attack = new M_FlyerAttack(this, stateMachine, "Attack", this);
        dead = new M_FlyerDead(this, stateMachine, "Dead", this);
        hide = new M_FlyerHide(this, stateMachine, "Hide", this);
        hit = new M_FlyerHit(this, stateMachine, "Hit", this);
        move = new M_FlyerMove(this, stateMachine, "Move", this);
        
        
        stateMachine.Initiate(move);


        active.enabled = false;
        inactive.enabled = false;
        
        int x = (int)((Random.Range(1, 3) - 1.5) * 2);
        moveLocation = new Vector3(Random.Range(2f, 15f)*x, Random.Range(-2f, 5f),0);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

        public Vector2 FlyerMove()
    {
        flyerVec = new Vector2((moveLocation.x - transform.position.x),
                (moveLocation.y - transform.position.y));
        flyerVec = flyerVec.normalized;
        return flyerVec;
    }

    public void EndHide()
    {
        stateMachine.ChangeState(move);
    }

    public void EndApper()
    {
        stateMachine.ChangeState(attack);
    }

    public void EndAttack()
    {
        currentAttackTimes++;
    }

    public void EndMove()
    {
        stateMachine.ChangeState(appear);
    }
}

