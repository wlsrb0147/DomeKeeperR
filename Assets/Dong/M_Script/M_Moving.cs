using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Moving : M_Base
{
    public Vector2 moveSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
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
