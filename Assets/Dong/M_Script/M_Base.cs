using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Base : MonoBehaviour
{
    public M_StateMachine stateMachine { get; private set; }
    public Animator ani;
    public Rigidbody2D rb;

    public Transform domeCenter;
    public float hp;
    
    public int faceX = 1;


    protected virtual void Awake()
    {
        stateMachine = new M_StateMachine();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        domeCenter = GameObject.Find("Dome_Center").GetComponent<Transform>();
    }
    
    protected virtual void Start()
    {
  
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();

        if (transform.position.x > domeCenter.position.x)
        {
            faceX = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            faceX = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
