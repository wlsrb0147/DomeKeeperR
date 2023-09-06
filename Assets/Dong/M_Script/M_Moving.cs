using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class M_Moving : M_Base
{
    public Vector2 moveSpeed;
    [SerializeField] float idleTime =0.5f;
    float idleTimer = 0;
    Vector2 InitialmoveSpeed;

    protected override void Awake()
    {
        base.Awake();
        InitialmoveSpeed = moveSpeed;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();


        if ( currentHP != HP1)
        {
            currentHP = HP1;
            idleTimer = 0;
            ChangeAniVelocity(0.5f);
        }

        else if (idleTimer >= idleTime)
        {
            ChangeAniVelocity(1f);
        }

        idleTimer += Time.deltaTime;


    }

    protected override void ChangeAniVelocity(float x)
    {
        base.ChangeAniVelocity(x);

        moveSpeed = InitialmoveSpeed * x;
        ani.SetFloat("AniSpeed", x);

    }

    public void SetVelocity(Vector2 vec)
    {
        if(rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(vec.x * faceX, vec.y);
        }
    }

    public void SetVecVelocity(float InputX, float InputY)
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            if (transform.position.x > domeCenter.transform.position.x)
            {
                rb.velocity = new Vector2(-InputX * faceX, InputY);
            }
            else rb.velocity = new Vector2(InputX * faceX, InputY);
        }
    }

    public Vector2 Getdir()
    {
        Vector2 dir;
        dir = domeCenter.position - transform.position; 
        return dir;
    }

    public void Jump(Vector2 pulsePower)
    {
        rb.AddForce(new Vector2(pulsePower.x * faceX, pulsePower.y), ForceMode2D.Impulse);
    }
}
