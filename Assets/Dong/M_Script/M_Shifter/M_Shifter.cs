using JetBrains.Annotations;
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

    public int shiftCounter;
    public int shiftCount;

    public GameObject bullet;
    public Transform shootPosition;

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

        int x = (int)((Random.Range(1, 3) - 1.5) * 2);
        transform.position = new Vector2(Random.Range(2f, 15f) * x, Random.Range(-2f, 5f));
        shiftCounter = Random.Range(2, 4);

        stateMachine.Initiate(appear);

    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.ChangeState(dead);
        }
    }

    public void EndAppear()
    {
        stateMachine.ChangeState(idle);
    }

    public void EndIdle()
    {
        if (shiftCounter <= shiftCount)
        {
            stateMachine.ChangeState(attack);
        }
        else
            stateMachine.ChangeState(shift);
    }

    public void EndShift()
    {
        stateMachine.ChangeState(appear);
    }

    public void EndAttack()
    {
        stateMachine.ChangeState(shift);
    }

    public void Shoot()
    {
        GameObject bulletPrefab = Instantiate(bullet,shootPosition.position,Quaternion.identity);
        bulletPrefab.SetActive(true);
    }
}
