using Unity.VisualScripting;
using UnityEngine;

public class M_Driller : M_Moving
{
    public M_DrillerAttacking attacking { get; private set; }
    public M_DrillerAttackingDead attackingDead { get; private set; }
    public M_DrillerAttackStart attackStart { get; private set; }
    public M_DrillerMove move { get; private set; }
    public M_DrillerMovingDead movingDead { get; private set; }
    public M_DrillerSetting setting { get; private set; }

    public bool settingOn { get; set; }

    protected override void Awake()
    {

        base.Awake();
        transform.Rotate(0, 180, 0);
        attacking = new M_DrillerAttacking(this, stateMachine, "Attacking", this);
        attackingDead = new M_DrillerAttackingDead(this, stateMachine, "AttackingDead", this);
        attackStart = new M_DrillerAttackStart(this, stateMachine, "AttackStart", this);
        move = new M_DrillerMove(this, stateMachine, "Move", this);
        movingDead = new M_DrillerMovingDead(this, stateMachine, "MovingDead", this);
        setting = new M_DrillerSetting(this, stateMachine, "Setting", this);
        settingOn = false;
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initiate(move);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.S))
        {
            Dead();
        }
    }

    protected override void Dead()
    {
        if (settingOn) stateMachine.ChangeState(attackingDead);
        else stateMachine.ChangeState(movingDead);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Dome"))
        {
            stateMachine.ChangeState(setting);
        }
    }

    public void Attackstart()
    {
        stateMachine.ChangeState(attackStart);
    }

    public void Attacking()
    {
        stateMachine.ChangeState(attacking);
    }


}
