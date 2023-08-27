using System.Xml.Serialization;
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

    public GameObject bullet;

    public float attackTimer_Min;
    public float attackTimer_Max;
    public float wakeUpTimer_Min;
    public float wakeUpTimer_Max;

    public int attackCount = 0;
    public int attackCounter;
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

    public void EndWakeUP()
    {
        stateMachine.ChangeState(idle);
    }

    public void EndAttack()
    {
        stateMachine.ChangeState(idle);
    }

    public void EndIdle()
    {
        if (attackCount == attackCounter)
        {
            stateMachine.ChangeState(hide);
            attackCount = 0;
        }
    }

    public void Attack()
    {
      GameObject bulletPrefab =  Instantiate(bullet);
        bulletPrefab.SetActive(true);
    }

}
