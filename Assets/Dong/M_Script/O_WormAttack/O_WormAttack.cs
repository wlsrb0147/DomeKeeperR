using UnityEngine;

public class O_WormAttack : M_Base
{
    public Collider2D myCollider;

    public O_WormAttackAttack attack { get; private set; }
    public O_WormAttackDead dead { get; private set; }
    public O_WormAttackHit hit { get; private set; }

    float distance;

    protected override void Awake()
    {
        base.Awake();
        myCollider = rb.GetComponent<Collider2D>();
        attack = new O_WormAttackAttack(this, stateMachine, "Attack", this);
        dead = new O_WormAttackDead(this, stateMachine, "Dead", this);
        hit = new O_WormAttackHit(this, stateMachine, "Hit", this);

        stateMachine.Initiate(attack);
    }

    protected override void Start()
    {
        base.Start();
        distance = domeCenter.position.x - transform.position.x;
        rb.AddForce(new Vector2(distance/2, Mathf.Abs(distance)*3/5), ForceMode2D.Impulse);
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


    /*   private void Awake()
       {
           rb = GetComponent<Rigidbody2D>();
           myCollider = rb.GetComponent<Collider2D>();

           attack = new O_WormAttackAttack(this, stateMachine, "Attack", this);


       }
       private void Start()
       {
           rb = GetComponent<Rigidbody2D>();
           rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

       }

       private void Update()
       {

       }*/
}
