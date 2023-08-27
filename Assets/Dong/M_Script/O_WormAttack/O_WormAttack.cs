using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_WormAttack : MonoBehaviour
{
    Rigidbody2D rb;
    public int forceX,forceY;
    public Collider2D bulletCollider;
    public Collider2D myCollider;

    public O_WormAttackAttack attack { get; private set; }
    public O_WormAttackDead dead { get; private set; }
    public O_WormAttackHit hit { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = rb.GetComponent<Collider2D>();

      //  attack = new O_WormAttackAttack(this, stateMachine, "Attack", this);


    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

    }

    private void Update()
    {
        
    }
}
